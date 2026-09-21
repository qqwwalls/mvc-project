using Microsoft.AspNetCore.Mvc;

namespace mvc;

public class HtmlResult : ContentResult
{
    public HtmlResult(string html)
    {
        Content = html;
        ContentType = "text/html; charset=utf-8";
    }
}
