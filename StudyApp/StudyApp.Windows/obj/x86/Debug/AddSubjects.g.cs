﻿

#pragma checksum "D:\Visual Studio 2013\Projects\StudyApp\StudyApp\StudyApp.Shared\AddSubjects.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FDDE77B26267DED7DE0D1904622DE38B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudyApp
{
    partial class AddSubjects : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 23 "..\..\..\AddSubjects.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnBack_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 21 "..\..\..\AddSubjects.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnAddSubject_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


