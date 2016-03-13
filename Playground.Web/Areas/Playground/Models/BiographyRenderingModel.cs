using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Playground.Web.Areas.Playground.Models
{
    using Data;
    using Score.UI.Data.RenderingParameters;
    using Score.UI.Web.Areas.ScoreUI.Models;
    using Sitecore.Data.Items;

public class BiographyRenderingModel : RenderingModelBase<HighlightParameters, BiographyDatasource>
{
    public BiographyRenderingModel() : base("biography-wrapper")
    {
    }

    protected override BiographyDatasource InitializeDatasource(Item item)
    {
        BiographyDatasource ds;
        return BiographyDatasource.TryParse(item, out ds) ? ds : null;
    }
}
}