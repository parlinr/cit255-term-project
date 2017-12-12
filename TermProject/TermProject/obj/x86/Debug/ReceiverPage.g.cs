﻿#pragma checksum "C:\Users\parlinr\Desktop\cit255-term-project\TermProject\TermProject\ReceiverPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7CC70E6C1E41799D751C41111B672093"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TermProject
{
    partial class ReceiverPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        internal class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        private class ReceiverPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IReceiverPage_Bindings
        {
            private global::TermProject.ReceiverPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.GridView obj16;

            private ReceiverPage_obj1_BindingsTracking bindingsTracking;

            public ReceiverPage_obj1_Bindings()
            {
                this.bindingsTracking = new ReceiverPage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 16:
                        this.obj16 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        break;
                    default:
                        break;
                }
            }

            // IReceiverPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            // ReceiverPage_obj1_Bindings

            public void SetDataRoot(global::TermProject.ReceiverPage newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.dataRoot = newDataRoot;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::TermProject.ReceiverPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_Receivers(obj.Receivers, phase);
                    }
                }
            }
            private void Update_Receivers(global::System.Collections.ObjectModel.ObservableCollection<global::TermProject.Receiver> obj, int phase)
            {
                if((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj16, obj, null);
                }
            }

            private class ReceiverPage_obj1_BindingsTracking
            {
                global::System.WeakReference<ReceiverPage_obj1_Bindings> WeakRefToBindingObj; 

                public ReceiverPage_obj1_BindingsTracking(ReceiverPage_obj1_Bindings obj)
                {
                    WeakRefToBindingObj = new global::System.WeakReference<ReceiverPage_obj1_Bindings>(obj);
                }

                public void ReleaseAllListeners()
                {
                }

                public void PropertyChanged_Receivers(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ReceiverPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::TermProject.Receiver> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::TermProject.Receiver>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_Receivers(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    ReceiverPage_obj1_Bindings bindings;
                    if(WeakRefToBindingObj.TryGetTarget(out bindings))
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::TermProject.Receiver> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::TermProject.Receiver>;
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2:
                {
                    this.addReceiverDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 3:
                {
                    this.updateReceiverDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 4:
                {
                    this.queryReceiverDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 5:
                {
                    this.deleteReceiverDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 6:
                {
                    this.selectReceiverByRecordNumberDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 7:
                {
                    this.sortReceiverDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 8:
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 295 "..\..\..\ReceiverPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.GetAllReceiversButton_Clicked;
                    #line default
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 297 "..\..\..\ReceiverPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.ClearScreenButton_Clicked;
                    #line default
                }
                break;
            case 10:
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 299 "..\..\..\ReceiverPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.AddReceiverButton_Clicked;
                    #line default
                }
                break;
            case 11:
                {
                    global::Windows.UI.Xaml.Controls.Button element11 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 301 "..\..\..\ReceiverPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element11).Click += this.DeleteReceiverButton_Clicked;
                    #line default
                }
                break;
            case 12:
                {
                    global::Windows.UI.Xaml.Controls.Button element12 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 303 "..\..\..\ReceiverPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element12).Click += this.UpdateReceiverButton_Clicked;
                    #line default
                }
                break;
            case 13:
                {
                    global::Windows.UI.Xaml.Controls.Button element13 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 305 "..\..\..\ReceiverPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element13).Click += this.SelectReceiverByRecordNumberButton_Clicked;
                    #line default
                }
                break;
            case 14:
                {
                    global::Windows.UI.Xaml.Controls.Button element14 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 307 "..\..\..\ReceiverPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element14).Click += this.QueryReceiversButton_Clicked;
                    #line default
                }
                break;
            case 15:
                {
                    global::Windows.UI.Xaml.Controls.Button element15 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 309 "..\..\..\ReceiverPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element15).Click += this.SortReceiversButton_Clicked;
                    #line default
                }
                break;
            case 17:
                {
                    this.scoreCheckbox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 18:
                {
                    this.yardsCheckbox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 19:
                {
                    this.touchdownsCheckbox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 20:
                {
                    this.selectRecordNumberInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 21:
                {
                    this.recordNumberInput = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 22:
                {
                    this.queryMaxTouchdownsTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 23:
                {
                    this.queryMinTouchdownsTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 24:
                {
                    this.queryMaxYardsTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 25:
                {
                    this.queryMinYardsTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 26:
                {
                    this.queryMaxScoreTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 27:
                {
                    this.queryMinScoreTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 28:
                {
                    this.updateRecordNumberTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 29:
                {
                    this.updateTouchdownsTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 30:
                {
                    this.updateYardsTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 31:
                {
                    this.updateTeamNameShortTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 32:
                {
                    this.updateTeamNameLongTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 33:
                {
                    this.updateFirstNameTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 34:
                {
                    this.updateLastNameTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 35:
                {
                    this.updateScoreTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 36:
                {
                    this.recordNumberTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 37:
                {
                    this.touchdownsTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 38:
                {
                    this.yardsTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 39:
                {
                    this.teamNameShortTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 40:
                {
                    this.teamNameLongTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 41:
                {
                    this.firstNameTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 42:
                {
                    this.lastNameTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 43:
                {
                    this.scoreTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ReceiverPage_obj1_Bindings bindings = new ReceiverPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

