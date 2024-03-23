using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopsDefault.AdminTools.UserControls.FilesManager
{
    public partial class main : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                System.IO.DirectoryInfo RootDir = new System.IO.DirectoryInfo(Server.MapPath("~/images/UploadImages/"));
                // output the directory into a node
                TreeNode RootNodeFolder = OutputDirectoryFolder(RootDir, null);

                TreeNode RootNodeFiles = OutputDirectoryFiles(RootDir, null);
                // add the output to the tree

                tvFolderManager.Nodes.Add(RootNodeFolder);
                tvFilesManager.Nodes.Add(RootNodeFiles);

            }
        }

        TreeNode OutputDirectoryFolder(System.IO.DirectoryInfo directory, TreeNode parentNode)
        {
            // validate param
            if (directory == null) return null;

            // create a node for this directory

            TreeNode DirNode = new TreeNode(directory.Name);
            // get subdirectories of the current directory

            System.IO.DirectoryInfo[] SubDirectories = directory.GetDirectories();

            // OutputDirectory(SubDirectories[0], "Directories");

            // output each subdirectory

            for (int DirectoryCount = 0; DirectoryCount < SubDirectories.Length; DirectoryCount++)

            {

                OutputDirectoryFolder(SubDirectories[DirectoryCount], DirNode);

            }

            // output the current directories file

            //System.IO.FileInfo[] Files = directory.GetFiles();

            //for (int FileCount = 0; FileCount < Files.Length; FileCount++)

            //{

            //    DirNode.ChildNodes.Add(new TreeNode(Files[FileCount].Name));

            //}        // if the parent node is null, return this node

            // otherwise add this node to the parent and return the parent

            if (parentNode == null)

            {

                return DirNode;

            }

            else

            {

                parentNode.ChildNodes.Add(DirNode);

                return parentNode;
            }
        }



        TreeNode OutputDirectoryFiles(System.IO.DirectoryInfo directory, TreeNode parentNode)
        {
            // validate param
            if (directory == null) return null;

            // create a node for this directory

            TreeNode DirNode = new TreeNode(directory.Name);
            // get subdirectories of the current directory

            System.IO.DirectoryInfo[] SubDirectories = directory.GetDirectories();

            // OutputDirectory(SubDirectories[0], "Directories");

            // output each subdirectory

            //for (int DirectoryCount = 0; DirectoryCount < SubDirectories.Length; DirectoryCount++)

            //{

            //    OutputDirectoryFiles(SubDirectories[DirectoryCount], DirNode);

            //}

            // output the current directories file

            System.IO.FileInfo[] Files = directory.GetFiles();

            for (int FileCount = 0; FileCount < Files.Length; FileCount++)

            {

                DirNode.ChildNodes.Add(new TreeNode(Files[FileCount].Name));

            }        // if the parent node is null, return this node

            // otherwise add this node to the parent and return the parent
            return DirNode;
            //if (parentNode == null)

            //{

            //    return DirNode;

            //}

            //else

            //{

            //    parentNode.ChildNodes.Add(DirNode);

            //    return parentNode;
            //}
        }

    }
}