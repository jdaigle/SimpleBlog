<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SimpleBlog.Web.Models.Article>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>List</title>
</head>
<body>    
    <% foreach (var article in Model) { %>
        <h1><%= Html.ActionLink(article.Title, MVC.Articles.Details(article.Id)) %></h1>
        <h2><%= article.ShowOn.ToLongDateString() %></h2>
        <p>
            <%= Html.Markdown(article.Content) %>
        </p>
    <% } %>
    
    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>
</body>
</html>

