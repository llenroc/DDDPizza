using System;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http.Routing;
using DDDPizza.ViewModels.Inventory;

namespace DDDPizza.Api.Factories
{
    public interface IResponseEnricher
    {
        bool CanEnrich(HttpResponseMessage response);
        HttpResponseMessage Enrich(HttpResponseMessage response);
    }

    public class PostResponseEnricher : ObjectContentResponseEnricher<InventoryVm>
    {
        public override void Enrich(InventoryVm post)
        {
        
        }
    }

    public abstract class ObjectContentResponseEnricher<T> : IResponseEnricher
    {
        public virtual bool CanEnrich(Type contentType)
        {
            return contentType == typeof(T);
        }

        public abstract void Enrich(T content);

        bool IResponseEnricher.CanEnrich(HttpResponseMessage response)
        {
            var content = response.Content as ObjectContent;
            return (content != null && CanEnrich(content.ObjectType));
        }

        HttpResponseMessage IResponseEnricher.Enrich(HttpResponseMessage response)
        {
            T content;
            if (response.TryGetContentValue(out content))
            {
                Enrich(content);
            }

            return response;
        }
    }
}