using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDDPizza.ViewModels.Inventory
{
    public class InventoryVm : Resource
    {
        public Guid Id { get; set; }
        public InventoryTypeVm Type { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name can be no larger than 30 characters")]
        public string Name { get; set; }
       
    }


    public abstract class Link
    {
        public string Rel { get; private set; }
        public string Href { get; private set; }
        public string Title { get; private set; }

        public Link(string relation, string href, string title = null)
        {
       
            Rel = relation;
            Href = href;
            Title = title;
        }
    }

    public abstract class Resource
    {
        private readonly List<Link> links = new List<Link>();
        public IEnumerable<Link> Links { get { return links; } }

        public void AddLink(Link link)
        {
          
            links.Add(link);
        }

      
    }
}