using advancewebtosolution.BO;
using One2Print.Library.Security;
using System;
using System.Data;
namespace advancewebtosolution
{
    public partial class Admin_Baner_UploadBaner : System.Web.UI.Page
    {
        #region
        protected void GetBanerImage(int BanerID)
        {
            StoreFront ObjStoreFront = new StoreFront();
            DataSet ds = new DataSet();
            ds = ObjStoreFront.GetBanerImage(BanerID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["ImageName"].ToString() != "")
                {
                    ImgService.ImageUrl = Session["HomePath"] + "StoreData/Baner/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
                    ViewState["ImageName"] = ds.Tables[0].Rows[0]["ImageName"].ToString();
                }
                else
                    ImgService.ImageUrl = Session["HomePath"] + "StoreData/Baner/Not.jpg";
            }
            else
            {

            }
        }

        public void ErrMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "errorTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            lblError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["BanerID"] != "")
                {
                    int BanerID = int.Parse(Request.QueryString["BanerID"]);
                    GetBanerImage(BanerID);
                }
                else
                {
                    Response.Redirect("ManageBaner.aspx");
                }
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //try
            //{


            if (flUploadDetail.PostedFile != null)
            {
                string ImageName2 = System.IO.Path.GetFileName(flUploadDetail.PostedFile.FileName);
                if (ImageName2 != "")
                {
                    string ext = System.IO.Path.GetExtension(flUploadDetail.FileName);
                    //if (ImageName2 != "" && ext == ".gif" || ext == ".jpg" || ext == ".png" || ext == ".bmp")
                    {
                        System.Drawing.Image image12 = System.Drawing.Image.FromFile(flUploadDetail.PostedFile.FileName);
                        if ((image12.Width > 668) || (image12.Height > 256))
                        {
                            ErrMessage("File Size Not Supported");

                        }
                        else
                        {
                            if (ViewState["ImageName"] != null)
                            {
                                string LogicalPath = Session["HomePath"] + "StoreData/Baner/" + ViewState["ImageName"].ToString();
                                string physicalPath = ContentManager.GetPhysicalPath(LogicalPath);
                                if (System.IO.File.Exists(physicalPath))
                                {
                                    System.IO.File.Delete(physicalPath);
                                }
                            }
                            string NewImageName = RandomStringsAndNumbers.Generate() + ext;
                            string virtualpath2 = Session["HomePath"] + "StoreData/Baner/" + NewImageName;
                            string fullpath2 = ContentManager.GetPhysicalPath(virtualpath2);
                            {
                                flUploadDetail.PostedFile.SaveAs(fullpath2);
                                ViewState["ImageName"] = NewImageName.ToString();
                                ImgService.Visible = true;
                                ImgService.ImageUrl = Session["HomePath"] + "StoreData/Baner/" + NewImageName;
                            }
                        }
                    }
                    //else
                    //{ ErrMessage("File Format Not Supported"); }
                }
                else
                {
                    ErrMessage("You Forgot To Select File Please Select File & Then Try.");
                }
            }
            // }
            //catch (FileNotFoundException e)
            //{
            //    Console.WriteLine(e.Message);

            //}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            StoreFront ObjStoreFront = new StoreFront();
            ObjStoreFront.UpdateBanerImage(Convert.ToInt32(Request.QueryString["BanerID"].ToString()), ViewState["ImageName"].ToString());
            SuccesfullMessage("Banner uploaded successfully");

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageBaner.aspx");
        }
    }
}