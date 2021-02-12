using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Models.ViewModels
{
    public class TeaViewModel
    {
        public List<Tea> TeaList { get; set; }
        public List<TeaIngredient> TeaIngredientsList { get; set; }
        public List<TeaIngredientLink> TeaIngredientsLinkList { get; set; }
        public List<TeaStore> TeaStoreList { get; set; }
        public List<TeaStoreLink> TeaStoreLinkList { get; set; }
        public List<TeaTags> TeaTagsList { get; set; }
        public List<TeaTagsLink> TeaTagsLinksList { get; set; }
    }
}
