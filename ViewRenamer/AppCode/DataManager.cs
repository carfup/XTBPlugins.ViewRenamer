using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Carfup.XTBPlugins.AppCode
{
    public class DataManager
    {
        public CrmServiceClient service { get; set; } = null;
        public DataManager(CrmServiceClient service)
        {
            this.service = service;
        }

        public List<int> LoadLanguages()
        {
            var result = (RetrieveProvisionedLanguagesResponse)this.service.Execute(new RetrieveProvisionedLanguagesRequest());
            return result.RetrieveProvisionedLanguages.Select(lcid => lcid).ToList();
        }

        public List<EntityDetailledName> LoadEntities()
        {
            /*RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };

            // Retrieve the MetaData.
            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)this.service.Execute(request);*/


            EntityQueryExpression entityQueryExpression = new EntityQueryExpression
            {
                Criteria = new MetadataFilterExpression(LogicalOperator.Or),
                Properties = new MetadataPropertiesExpression
                {
                    AllProperties = false,
                    PropertyNames = { "DisplayName", "LogicalName", "ObjectTypeCode", "SchemaName" }
                }
            };

            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
            {
                Query = entityQueryExpression,
                ClientVersionStamp = null
            };

            RetrieveMetadataChangesResponse response = (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);


            List<EntityDetailledName> edn = new List<EntityDetailledName>();

            edn = response.EntityMetadata.Where(x => x.DisplayName?.UserLocalizedLabel?.Label != null).Select(entity => new EntityDetailledName
            {
                displayName = entity.DisplayName?.UserLocalizedLabel?.Label,
                logicalName = entity.LogicalName,
                schemaName = entity.SchemaName
            }).ToList();

           /* foreach (var entity in response.EntityMetadata)
            {
                if (entity.DisplayName?.UserLocalizedLabel?.Label == null)
                    continue;

                edn.Add(new EntityDetailledName()
                {
                    displayName = entity.DisplayName?.UserLocalizedLabel?.Label,
                    logicalName = entity.LogicalName,
                    schemaName = entity.SchemaName
                });
            }*/

            return edn.OrderBy(x => x.displayName).ToList();
        }

        public List<Entity> RetrieveViews(string[] objectTypeCode)
        {
            try
            {
                var qba = new QueryExpression
                {
                    EntityName = "savedquery",
                    ColumnSet = new ColumnSet("returnedtypecode", "querytype"),
                    Criteria =
                    {
                        Conditions =
                        {
                            new ConditionExpression("returnedtypecode", ConditionOperator.In, objectTypeCode)
                        }
                    },
                    Orders =
                    {
                        new OrderExpression("returnedtypecode", OrderType.Ascending)
                    }
                };


                EntityCollection views = this.service.RetrieveMultiple(qba);

                return views.Entities.ToList();
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving views: " + error.Message);
            }
        }

        public class EntityDetailledName
        {
            public string logicalName { get; set; }
            public string schemaName { get; set; }
            public string displayName { get; set; }
        }
    }
}
