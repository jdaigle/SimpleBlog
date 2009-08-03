<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SimpleBlog.Web.Models.Article>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>List</title>
</head>
<body>
    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Title
            </th>
            <th>
                Content
            </th>
            <th>
                ShowOn
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.Id })%>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.Content) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ShowOn)) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</body>
</html>

