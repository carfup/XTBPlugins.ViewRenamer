using Carfup.XTBPlugins.AppCode;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using static Carfup.XTBPlugins.AppCode.DataManager;

namespace Carfup.XTBPlugins.ViewRenamer
{
    public partial class ViewRenamer : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        private Settings mySettings;
        private DataManager dm = null;
        private List<EntityDetailledName> entities = null;
        private List<CrmView> crmViews = null;
        private List<CrmView> crmViewsModified = new List<CrmView>();
        private List<int> languages = null;
        DataTable dataTable = new DataTable();
        private int currentColumnOrder;
        public LogUsageManager log = null;
        internal PluginSettings settings = new PluginSettings();

        public string RepositoryName => "XTBPlugins.ViewRenamer";
        public string UserName => "carfup";
        public string EmailAccount => "clement@carfup.com";
        public string DonationDescription => "Thanks a lot for your support, this really mean something to me, and push me to keep going for sure ! Long life to View Renamer ! =)";

        public ViewRenamer()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            log = new LogUsageManager(this);
            log.LogData(EventType.Event, LogAction.SettingLoaded);
            LoadSetting();

            dgvViewsToRename.DataSource = dataTable;

            cbLanguageReplace.SelectedText = "All";
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

       
        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            dm = new DataManager(detail.ServiceClient);
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }

            //ExecuteMethod(LoadEntities);
        }

        private void lvEntities_DoubleClick(object sender, EventArgs e)
        {
            ExecuteMethod(GetViewsForSelectedEntities);
        }

        private void GetViewsForSelectedEntities()
        {
            var selectedItems = new List<string>();

            if(lvEntities.CheckedItems.Count == 0)
                MessageBox.Show("you need to select table(s) in order to load the related views.", "No tables selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            foreach (ListViewItem entity in lvEntities.CheckedItems)
                selectedItems.Add(entity.Text);
                
            var entityCode = entities.Where(x => selectedItems.Contains(x.displayName)).Select(x => x.logicalName).ToArray();
            crmViews = new List<CrmView>();
            

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting the views for " + String.Join(",", selectedItems.ToArray()),
                Work = (worker, args) =>
                {
                    var views = dm.RetrieveViews(entityCode);
                    foreach (var view in views)
                    {
                        var crmView = crmViews.FirstOrDefault(cv => cv.Id == view.Id);
                        if (crmView == null)
                        {
                            crmView = new CrmView
                            {
                                Id = view.Id,
                                Entity = view.GetAttributeValue<string>("returnedtypecode"),
                                Type = view.GetAttributeValue<int>("querytype"),
                                Names = new Dictionary<int, string>(),
                            };
                            crmViews.Add(crmView);
                        }

                        // Names
                        RetrieveLocLabelsRequest request = new RetrieveLocLabelsRequest
                        {
                            AttributeName = "name",
                            EntityMoniker = new EntityReference("savedquery", view.Id)
                        };

                        RetrieveLocLabelsResponse response = (RetrieveLocLabelsResponse)Service.Execute(request);
                        foreach (var locLabel in response.Label.LocalizedLabels)
                        {
                            crmView.Names.Add(locLabel.LanguageCode, locLabel.Label);
                        }
                    }
                    args.Result = crmViews;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.LogData(EventType.Exception, LogAction.LoadViewsForEntity, args.Error);
                    }
                    var result = args.Result as List<CrmView>;
                    if (result != null)
                    {
                        FillDataGrid(result);
                    }

                    log.LogData(EventType.Event, LogAction.LoadViewsForEntity);
                }
            });
        }

        private void tbsLoadData_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        private void LoadEntities()
        {
            lvEntities.Items.Clear();
            dgvViewsToRename.Columns.Clear();
            dataTable.Columns.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting the Tables ...",
                Work = (worker, args) =>
                {
                    languages = dm.LoadLanguages();
                    entities = dm.LoadEntities();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.LogData(EventType.Exception, LogAction.LoadEntities, args.Error);
                    }

                    List<ListViewItem> cbItems = new List<ListViewItem>();
                    cbItems.AddRange(entities.Select(entity => new ListViewItem()
                    {
                        Text = entity.displayName,
                        Tag = entity.logicalName
                    }));
                 
                    lvEntities.Items.AddRange(cbItems.ToArray());

                    foreach (var language in languages.OrderBy(x => x))
                    {
                        var l = language.ToString();
                        if (!dataTable.Columns.Contains(l))
                            dataTable.Columns.Add(l);

                        if (!cbLanguageReplace.Items.Contains(l))
                            cbLanguageReplace.Items.Add(l);
                    }

                    log.LogData(EventType.Event, LogAction.LoadEntities);
                }
            });
        }

        private void dgvViewsToRename_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;

            DataGridViewRow row = dgvViewsToRename.Rows[e.RowIndex];
            var columnIndex = e.ColumnIndex;

            crmViews[e.RowIndex].Modified = true;
            crmViews[e.RowIndex].Names[languages[columnIndex]] = row.Cells[columnIndex].Value.ToString();
            crmViewsModified.Add(crmViews[e.RowIndex]);

            tsbSaveViews.Enabled = true;
        }

        private void tsbSaveViews_Click(object sender, EventArgs e)
        {
            if(crmViewsModified.Count == 0)
                MessageBox.Show("The are no modified views !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Saving the modified views...",
                Work = (worker, args) =>
                {
                    foreach (var modifiedView in crmViewsModified)
                    {
                        var labels = new List<LocalizedLabel>();
                        foreach (var l in languages)
                        {
                            var label = modifiedView.Names.Where(x => x.Key == l).FirstOrDefault().Value;
                            var translatedLabel = new LocalizedLabel(label, l);
                            labels.Add(translatedLabel);
                        }

                        var request = new SetLocLabelsRequest
                        {
                            EntityMoniker = new EntityReference("savedquery", modifiedView.Id),
                            AttributeName = "name",
                            Labels = labels.ToArray()
                        };

                        var response = (SetLocLabelsResponse)Service.Execute(request);
                    } 
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.LogData(EventType.Exception, LogAction.SaveViews, args.Error);
                    }

                    crmViewsModified.Clear();

                    MessageBox.Show("The modified view names were proceed successfully`\n\rYou need to publish in order to apply the changes and view these.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tsPublish.Enabled = true;
                    log.LogData(EventType.Event, LogAction.SaveViews);
                }
            });
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (tbFilter.Text == "" || tbFilter.Text.Length < 3)
                return; 

            lvEntities.Items.Clear();
            var newList = entities.Where(x => x.displayName.ToLower().Contains(tbFilter.Text.ToLower()));

            List<ListViewItem> cbItems = new List<ListViewItem>();
            cbItems.AddRange(newList.Select(entity => new ListViewItem()
            {
                Text = entity.displayName,
                Tag = entity.logicalName
            }));

            lvEntities.Items.AddRange(cbItems.ToArray());
        }

        private void tbFilter_Click(object sender, EventArgs e)
        {
            if (tbFilter.Text.ToLower() == "search in tables ...")
                tbFilter.Text = "";
        }

        private void SortListView(ListView listView, int columnIndex, SortOrder? sort = null)
        {
            if (sort != null)
            {
                listView.ListViewItemSorter = new ListViewItemComparer(columnIndex, sort.Value);
            }
            else if (columnIndex == currentColumnOrder)
            {
                listView.Sorting = listView.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;

                listView.ListViewItemSorter = new ListViewItemComparer(columnIndex, listView.Sorting);
            }
            else
            {
                currentColumnOrder = columnIndex;
                listView.ListViewItemSorter = new ListViewItemComparer(columnIndex, SortOrder.Ascending);
            }
        }

        private void lvEntities_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortListView(lvEntities, e.Column);
        }

        private void tsPublish_Click(object sender, EventArgs e)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Publishing the customizations...",
                Work = (worker, args) =>
                {
                    Service.Execute(new PublishAllXmlRequest());
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.LogData(EventType.Exception, LogAction.PublishCustomizations, args.Error);
                    }

                    crmViewsModified.Clear();

                    MessageBox.Show("Publish is finished you can now see the updates in your organization.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tsbSaveViews.Enabled = false;
                    log.LogData(EventType.Event, LogAction.PublishCustomizations);
                }
            });
        }

        public static string CurrentVersion
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fileVersionInfo.ProductVersion;
            }
        }

        private void LoadSetting()
        {
            try
            {
                if (SettingsManager.Instance.TryLoad<PluginSettings>(typeof(ViewRenamer), out settings))
                {
                    return;
                }
                else
                    settings = new PluginSettings();
            }
            catch (InvalidOperationException ex)
            {
                log.LogData(EventType.Exception, LogAction.SettingLoaded, ex);
            }

            log.LogData(EventType.Event, LogAction.SettingLoaded);

            if (!settings.AllowLogUsage.HasValue)
            {
                log.PromptToLog();
                SaveSettings();
            }
        }

        public void SaveSettings(bool closeApp = false)
        {
            if (closeApp)
                log.LogData(EventType.Event, LogAction.SettingsSavedWhenClosing);
            else
                log.LogData(EventType.Event, LogAction.SettingsSaved);
            SettingsManager.Instance.Save(typeof(ViewRenamer), settings);
        }

        private void btnLoadViews_Click(object sender, EventArgs e)
        {
            ExecuteMethod(GetViewsForSelectedEntities);
        }

        private void btnReplaceText_Click(object sender, EventArgs e)
        {
            var from = tbReplaceFrom.Text;
            var to = tbReplaceTo.Text;
            var language = cbLanguageReplace.Text;
            var caseSensitive = chkCaseSensitive.Checked;
            var crmViewsSelected = new List<CrmView>();

            if (rbSelectedLines.Checked && dgvViewsToRename.SelectedRows.Count > 0)
            {
                var selectedRows = dgvViewsToRename.SelectedRows;

                foreach (DataGridViewRow s in selectedRows)
                    crmViewsSelected.Add(crmViews.ElementAt(s.Index));
            }

            var crmViewsReplace = new List<CrmView>();

            foreach(var view in crmViews.ToList())
            {
                var found = false;
                var crmView = new CrmView()
                {
                    Entity = view.Entity,
                    Id = view.Id,
                    Names = new Dictionary<int, string>(),
                    Modified = true,
                    Type = view.Type
                };
                
                foreach (var name in view.Names)
                {
                    var condition = language == "All" ? true : name.Key == Int32.Parse(language);
                    var valueToReplace = caseSensitive ? name.Value : name.Value.ToLower();
                    var fromCaseSensitive = caseSensitive ? from : from.ToLower();

                    if ((valueToReplace.Contains(fromCaseSensitive) || Regex.Matches(name.Value, from).Count > 0) 
                        && condition
                        && ((crmViewsSelected.Count > 0 && crmViewsSelected.Contains(view)) || rbAllLines.Checked)
                        )
                    {
                        var reg = caseSensitive ? new Regex(from, RegexOptions.None) : new Regex(from, RegexOptions.IgnoreCase);
                        var replace = reg.Replace(name.Value, to);

                        crmView.Names.Add(name.Key, replace);
                        found = true;
                    } 
                    else
                    {
                        crmView.Names.Add(name.Key, name.Value);
                    }
                }

                crmViewsReplace.Add(crmView);

                if(found)
                    crmViewsModified.Add(crmView);
            }

            crmViews = crmViewsReplace;
            FillDataGrid(crmViews);

            tsbSaveViews.Enabled = crmViewsModified.Count > 0;
        }

        private void FillDataGrid(List<CrmView> list)
        {
            dataTable.Rows.Clear();
            foreach (var crmView in list)
            {
                var dataRow = dataTable.NewRow();
                for (int i = 0; i < languages.Count; i++)
                {
                    var lcid = languages[i];
                    var name = crmView.Names.FirstOrDefault(n => n.Key == lcid).Value;
                    dataRow[i] = name;
                }

                dataTable.Rows.Add(dataRow);
            }

         //   for (int i = 0; i < dgvViewsToRename.Columns.Count; i++)
         //       dgvViewsToRename.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void lvEntities_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.Checked = e.IsSelected;
        }

        private void lvEntities_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btnLoadViews.Enabled = lvEntities?.CheckedItems.Count > 0;
        }

        private void tbReplaceFrom_TextChanged(object sender, EventArgs e)
        {
            btnReplaceText.Enabled = !String.IsNullOrEmpty(tbReplaceFrom.Text) && !String.IsNullOrEmpty(tbReplaceTo.Text);
        }

        private void tbReplaceTo_TextChanged(object sender, EventArgs e)
        {
            btnReplaceText.Enabled = !String.IsNullOrEmpty(tbReplaceFrom.Text) && !String.IsNullOrEmpty(tbReplaceTo.Text);
        }

        private void btnLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        private void rbSelectedLines_CheckedChanged(object sender, EventArgs e)
        {
            rbAllLines.Checked = !rbSelectedLines.Checked;
        }

        private void rbAllLines_CheckedChanged(object sender, EventArgs e)
        {
            rbSelectedLines.Checked = !rbAllLines.Checked;
        }

        private void btnRevertReplace_Click(object sender, EventArgs e)
        {
            var from = tbReplaceFrom.Text;
            tbReplaceFrom.Text = tbReplaceTo.Text;
            tbReplaceTo.Text = from;
        }
    }
}