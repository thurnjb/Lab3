<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerPortal.Master" AutoEventWireup="true" CodeBehind="Move.aspx.cs" Inherits="Lab3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Table ID="TableMove" runat="server" Height="300px" HorizontalAlign="Center">
     <asp:TableRow>

     <%--    <asp:TableCell>--%>
<%--             <asp:TextBox ID="TextBoxServiceNotes" runat="server"></asp:TextBox>--%>
           <%--  <asp:Button ID="ButtonAddNote" runat="server" Text="Add Note" OnClick="ButtonAddNote_Click" />
         </asp:TableCell>--%>
          <asp:TableCell>
                <asp:Label ID="lblNoteTitle" runat="server" Text="Note Title:" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNoteTitle" Width="300px" runat="server" ></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelContent" runat="server" Text="Enter Content: "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNoteContent" runat="server" Height="100px" Width="300px" TextMode="MultiLine" ></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    
     <asp:TableRow>
         <asp:TableCell>
             <asp:Label ID="LabelUploadPhotos" runat="server" Text="Upload Photos: "></asp:Label>
         </asp:TableCell>
         <asp:TableCell>
             <asp:FileUpload ID="FileUpload1" Width="300px" runat="server" />
         </asp:TableCell>

     </asp:TableRow> <%--Original--%>
     
     
     <asp:TableRow>
         <asp:TableCell>
         <asp:Label ID="LabelRequestDate" runat="server" Text="Request Date/s: "></asp:Label>
         </asp:TableCell>
         <asp:TableCell>
             <asp:Calendar ID="Calendar1"  OnSelectionChanged="Calendar1_SelectionChanged" runat="server"></asp:Calendar>
         </asp:TableCell>
         <asp:TableCell>
             <asp:TextBox ID="TextBoxCalendar"  runat="server"></asp:TextBox>
         </asp:TableCell>
         
</asp:TableRow>
         <asp:TableRow>
             <asp:TableCell>
                 <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
             </asp:TableCell>
         </asp:TableRow>
 </asp:Table>


</asp:Content>

