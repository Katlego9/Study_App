﻿

#pragma checksum "D:\Visual Studio 2013\Projects\Study_App\StudyApp\StudyApp.Shared\TimeTable.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "840F9C36AAF3DC5A34AF284C33B23160"
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
    partial class TimeTable : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 14 "..\..\..\TimeTable.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnBack_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 12 "..\..\..\TimeTable.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.grdTimeTable_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


