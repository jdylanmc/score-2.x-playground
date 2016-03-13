using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Data
{
    using Score.Data.Extensions;
    using Score.UI.Data.DatasourceItems;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Web.UI.WebControls;

public class BiographyDatasource : ScoreUIItem
{
    public static class Fields
    {
        public const string Portrait = "Portrait";
        public const string Name = "Person Name";
        public const string Description = "Description";
    }
        
    public static readonly ID TemplateId = ID.Parse("{A3AA61C2-B969-408B-9428-F000DBF89427}");

    public BiographyDatasource(Item item) : base(item) { }

    public ImageField Portrait
    {
        get { return this.InnerItem.Fields[Fields.Portrait]; }
    }

    public string PersonName
    {
        get { return this.InnerItem.Fields[Fields.Name].Value; }
    }

    public string Description
    {
        get { return this.InnerItem.Fields[Fields.Description].Value; }
    }

    public static bool TryParse(Item item, out BiographyDatasource parsedItem)
    {
        parsedItem = item == null || item.IsDerived(TemplateId) == false ? null : new BiographyDatasource(item);
        return parsedItem != null;
    }
    public static implicit operator BiographyDatasource(Item innerItem)
    {
        return innerItem != null && innerItem.IsDerived(TemplateId) ? new BiographyDatasource(innerItem) : null;
    }
    public static implicit operator Item(BiographyDatasource customItem)
    {
        return customItem != null ? customItem.InnerItem : null;
    }
}
}

