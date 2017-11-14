namespace Sitecore.Support.Pipelines.Search
{
  using System;
  using Data;
  using Data.Items;
  using Diagnostics;
  using Globalization;
  using Sitecore.Pipelines.Search;
  using Sitecore.Search;

  public class IDResolver
  {
    public void Process(SearchArgs args)
    {
      Guid guid;
      Assert.ArgumentNotNull(args, "args");
      if (Guid.TryParse(args.TextQuery, out guid))
      {
        Item item = args.Database.GetItem(new ID(guid));
        if (item != null)
        {
          SearchResult result = SearchResult.FromItem(item);
          args.Result.AddResultToCategory(result, Translate.Text("Direct Hit"));
        }
      }
    }
  }
}
