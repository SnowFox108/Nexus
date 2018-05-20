using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core.Pages;
using Telerik.Web.UI;

namespace Nexus.Core
{
    public partial class App_AdminCP_SiteAdmin_Pages_PageMenu : System.Web.UI.UserControl
    {

        #region Properties

        private string _selected_pageindexid;
        private string _root_pageindexid = "-1";

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Selected_PageIndexID
        {
            get
            {
                return _selected_pageindexid;
            }
            set
            {
                _selected_pageindexid = value;
                ViewState["Selected_PageIndexID"] = _selected_pageindexid;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Root_PageIndexID
        {
            get
            {
                return _root_pageindexid;
            }
            set
            {
                _root_pageindexid = value;
                ViewState["Root_PageIndexID"] = _root_pageindexid;
            }
        }

        #endregion

        #region Events

        // LinkButton Click Event
        private static readonly object EventPageIndexSelected = new object();

        [Category("Action")]
        [Description("Raised Page Menu Clicked event")]
        public event RadTreeViewEventHandler PageIndexSelected
        {
            add
            {
                Events.AddHandler(EventPageIndexSelected, value);
            }
            remove
            {
                Events.RemoveHandler(EventPageIndexSelected, value);
            }
        }

        protected void OnPageIndexSelected(object sender, RadTreeNodeEventArgs e)
        {
            RadTreeViewEventHandler PageIndexSelectedHandler = (RadTreeViewEventHandler)Events[EventPageIndexSelected];

            if (PageIndexSelectedHandler != null)
                PageIndexSelectedHandler(sender, e);

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _selected_pageindexid = ViewState["Selected_PageIndexID"].ToString();
                    _root_pageindexid = ViewState["Root_PageIndexID"].ToString();
                }
                catch
                {
                }
            }
            else
            {
                LoadRootNodes();
            }
        }

        #region TreeView

        public void LoadRootNodes()
        {
            // Remove all Node before add new one
            RadTreeView_WebSite.Nodes.Clear();

            RadTreeNode rootnode = new RadTreeNode();
            rootnode.Text = "All Pages";
            rootnode.Value = _root_pageindexid;
            rootnode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
            rootnode.ImageUrl = "/App_Control_Style/NexusCore/Menu_TreeView/Icons/All_Pages.gif";
            rootnode.Expanded = true;
            RadTreeView_WebSite.Nodes.Add(rootnode);

            List<Nexus.Core.Pages.Menu_Nodes> RootNodes = Nexus.Core.Pages.SiteMenu.sGet_Menu_Nodes(_root_pageindexid);

            foreach (Nexus.Core.Pages.Menu_Nodes _menu_node in RootNodes)
            {
                RadTreeNode node = new RadTreeNode();
                node.Text = _menu_node.Menu_Title;
                node.Value = _menu_node.PageIndexID;

                if (_menu_node.ChildrenCount > 0)
                {
                    node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                }

                node.ImageUrl = _menu_node.IconUrl;

                RadTreeView_WebSite.Nodes.FindNodeByValue(_root_pageindexid).Nodes.Add(node);
            }

            SetPageIndexID();
        }

        private static void PopulateNodeOnDemand(RadTreeNodeEventArgs e)
        {

            List<Nexus.Core.Pages.Menu_Nodes> RootNodes = Nexus.Core.Pages.SiteMenu.sGet_Menu_Nodes(e.Node.Value);

            foreach (Nexus.Core.Pages.Menu_Nodes _menu_node in RootNodes)
            {
                RadTreeNode node = new RadTreeNode();
                node.Text = _menu_node.Menu_Title;
                node.Value = _menu_node.PageIndexID;

                if (_menu_node.ChildrenCount > 0)
                {
                    node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                }

                node.ImageUrl = _menu_node.IconUrl;

                e.Node.Nodes.Add(node);
            }

            e.Node.Expanded = true;
        }

        protected void RadTreeView_WebSite_NodeExpand(object sender, RadTreeNodeEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
                PopulateNodeOnDemand(e);

        }

        protected void RadTreeView_WebSite_NodeDrop(object sender, Telerik.Web.UI.RadTreeNodeDragDropEventArgs e)
        {
            RadTreeNode sourceNode = e.SourceDragNode;
            RadTreeNode destNode = e.DestDragNode;
            RadTreeViewDropPosition dropPosition = e.DropPosition;

            if (destNode != null) //drag&drop is performed between trees
            {
                if (sourceNode.TreeView.SelectedNodes.Count <= 1)
                {
                    PerformDragAndDrop(dropPosition, sourceNode, destNode);
                }
                else if (sourceNode.TreeView.SelectedNodes.Count > 1)
                {
                    foreach (RadTreeNode node in sourceNode.TreeView.SelectedNodes)
                    {
                        PerformDragAndDrop(dropPosition, node, destNode);
                    }
                }

                destNode.Expanded = true;
                //sourceNode.TreeView.ClearSelectedNodes();
                sourceNode.TreeView.UnselectAllNodes();

            }

        }

        private void PerformDragAndDrop(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode,
                                               RadTreeNode destNode)
        {
            if (sourceNode.Equals(destNode) || sourceNode.IsAncestorOf(destNode))
            {
                return;
            }

            // Check if destNote is Root when drop above and below it.
            if (dropPosition == RadTreeViewDropPosition.Above || dropPosition == RadTreeViewDropPosition.Below)
            {
                if (destNode.ParentNode == null)
                {
                    return;
                }

            }

            RadTreeNode srcNode = sourceNode.ParentNode;

            sourceNode.Owner.Nodes.Remove(sourceNode);

            switch (dropPosition)
            {
                case RadTreeViewDropPosition.Over:
                    // child
                    if (!sourceNode.IsAncestorOf(destNode))
                    {
                        destNode.Nodes.Add(sourceNode);

                        // Update Database structure
                        Nexus.Core.Pages.SiteMenu.sEdit_Menu_Nodes(sourceNode.Value, destNode.Value);
                        Nexus.Core.Pages.SiteMenu.sEdit_Menu_Nodes(srcNode, destNode);

                    }
                    break;

                case RadTreeViewDropPosition.Above:

                    // sibling - above					
                    destNode.InsertBefore(sourceNode);

                    // Update Database structure
                    Nexus.Core.Pages.SiteMenu.sEdit_Menu_Nodes(sourceNode.Value, destNode.ParentNode.Value);
                    Nexus.Core.Pages.SiteMenu.sEdit_Menu_Nodes(srcNode, destNode.ParentNode);

                    break;

                case RadTreeViewDropPosition.Below:

                    // sibling - below
                    destNode.InsertAfter(sourceNode);

                    // Update Database structure
                    Nexus.Core.Pages.SiteMenu.sEdit_Menu_Nodes(sourceNode.Value, destNode.ParentNode.Value);
                    Nexus.Core.Pages.SiteMenu.sEdit_Menu_Nodes(srcNode, destNode.ParentNode);

                    break;
            }
        }

        // Load Page
        protected void RadTreeView_WebSite_NodeClick(object sender, RadTreeNodeEventArgs e)
        {

            _selected_pageindexid = e.Node.Value;
            ViewState["Selected_PageIndexID"] = _selected_pageindexid;

            OnPageIndexSelected(sender, e);

        }

        private void SetPageIndexID()
        {
            if (!DataEval.IsEmptyQuery(_selected_pageindexid))
            {
                URLrewriter.UrlMgr myUrlMgr = new URLrewriter.UrlMgr();

                List<PageIndex> myPageIndexs = myUrlMgr.Get_PageIndex_Tree(_selected_pageindexid);

                foreach (PageIndex myPageIndex in myPageIndexs)
                {
                    RadTreeNode selectednode = RadTreeView_WebSite.FindNodeByValue(myPageIndex.PageIndexID);

                    if (selectednode != null)
                        ExpandSelectedNode(selectednode);
                }

                RadTreeNode _selectednode = RadTreeView_WebSite.FindNodeByValue(_selected_pageindexid);
                if (_selectednode != null)
                {
                    _selectednode.Selected = true;
                }
            }

        }

        private void ExpandSelectedNode(RadTreeNode SelectedNode)
        {

            List<Nexus.Core.Pages.Menu_Nodes> RootNodes = Nexus.Core.Pages.SiteMenu.sGet_Menu_Nodes(SelectedNode.Value);

            foreach (Nexus.Core.Pages.Menu_Nodes _menu_node in RootNodes)
            {
                RadTreeNode node = new RadTreeNode();
                node.Text = _menu_node.Menu_Title;
                node.Value = _menu_node.PageIndexID;

                if (_menu_node.ChildrenCount > 0)
                {
                    node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                }

                node.ImageUrl = _menu_node.IconUrl;

                SelectedNode.Nodes.Add(node);
            }

            SelectedNode.Expanded = true;
        }

        public void SetPageIndexID(string PageIndexID)
        {
            RadTreeNode selectednode = RadTreeView_WebSite.FindNodeByValue(PageIndexID);

            if (selectednode != null)
            {
                _selected_pageindexid = PageIndexID;
                selectednode.Selected = true;
            }

        }
        #endregion

    }
}