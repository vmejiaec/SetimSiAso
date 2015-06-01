<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="asoSocio_Edit.ascx.cs" Inherits="SetimMod_Socio.asoSocio_Edit" %>

<div id="dnnUsers" class="dnnForm dnnClear">
    <fieldset>
        <div class="dnnFormItem">
            <div class="dnnLabel">
                <asp:Label runat="server" ID="lblAux" Text="_taskId:"></asp:Label>
            </div>
        </div>
        <div class="dnnFormItem">
            <div class="dnnLabel"><asp:Label runat="server" ID="lbId" Text="Id:"></asp:Label></div>
            <asp:TextBox runat="server" ID="tbId" MaxLength="200"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <div class="dnnLabel"><asp:Label ID="lbUserId" runat="server" Text="UserId:"></asp:Label></div>
            <asp:TextBox runat="server" ID="tbUserId" MaxLength="100"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <div class="dnnLabel"><asp:Label ID="lbCI" runat="server" Text="CI:"></asp:Label></div>
            <asp:TextBox runat="server" ID="tbCI" MaxLength="100"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <div class="dnnLabel"><asp:Label ID="lbDescripcion" runat="server" Text="Descripcion:"></asp:Label></div>
            <asp:TextBox runat="server" ID="tbDescripcion" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <div class="dnnLabel"><asp:Label ID="lbFecha_Nacimiento" runat="server" Text="Fecha_Nacimiento:"></asp:Label></div>
            <asp:TextBox runat="server" ID="tbFecha_Nacimiento" MaxLength="100"></asp:TextBox>
        </div>
        <div class="dnnFormItem">
            <div class="dnnLabel"><asp:Label ID="lbEstado" runat="server" Text="Estado:"></asp:Label></div>
            <asp:TextBox runat="server" ID="tbEstado" MaxLength="50"></asp:TextBox>
        </div>
    </fieldset>
</div>

<ul class="dnnActions dnnClear">
    <li>
        <asp:LinkButton runat="server" ID="saveButton" 
            CssClass="dnnPrimaryAction"
            OnClick="Guardar"
            Text="Guardar"
            />
    </li>
    <li>
        <asp:LinkButton runat="server" ID="cancelButton"
            CssClass="dnnSecondaryAction"
            OnClick="Cancelar"
            Text="Cancelar" />
    </li>
</ul>