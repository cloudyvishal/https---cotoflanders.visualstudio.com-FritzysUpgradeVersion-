using System;
using System.Data;
using System.Web.UI;
using advancewebtosolution.BO;

public partial class FleaTick : System.Web.UI.Page
{
    /*
    Bind data function use to bind front end data that is cat and dog set for front end 
    */
    #region Declare
    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }

    public void BindData()
    {
        //StoreFront ObjStoreFront = new StoreFront();
        //DataSet ds = new DataSet();
        //ds = ObjStoreFront.GetFleaPageServices();
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    divCatService.InnerHtml = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
        //    imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/Images/" + ds.Tables[0].Rows[0]["Image"].ToString();
        //    imgCatservice.ToolTip = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
        //}
        //if (ds.Tables[1].Rows.Count > 0)
        //{
        //    divDogService.InnerHtml = ds.Tables[1].Rows[0]["ServiceDescription"].ToString();
        //    imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/Images/" + ds.Tables[1].Rows[0]["Image"].ToString();
        //    imgDogservice.ToolTip = ds.Tables[1].Rows[0]["ServiceDescription"].ToString();
        //}

        StoreFront ObjStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        if (Session["UserType"].ToString() == "4")
        {
            ds = ObjStoreFront.GetFleaandTickServices(4);
        }
        else
        {
            ds = ObjStoreFront.GetFleaandTickServices(Convert.ToInt32(Session["UserType"].ToString()));
        }

        if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["PetType"].ToString() == "1"))
        {
            divCatService.InnerHtml = ds.Tables[0].Rows[0]["Description"].ToString();
            imgCatservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
            imgCatservice.ToolTip = ds.Tables[0].Rows[0]["Description"].ToString();
        }
        if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[1]["PetType"].ToString() == "2"))
        {
            divDogService.InnerHtml = ds.Tables[0].Rows[1]["Description"].ToString();
            imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[1]["ImageName"].ToString();
            imgDogservice.ToolTip = ds.Tables[0].Rows[1]["Description"].ToString();
        }
        //if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[1]["PetType"].ToString() == "3"))
        //{
        //    divDogService.InnerHtml = ds.Tables[0].Rows[1]["Description"].ToString();
        //    imgDogservice.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[1]["ImageName"].ToString();
        //    imgDogservice.ToolTip = ds.Tables[0].Rows[1]["Description"].ToString();
        //}

    }
    #endregion

    /*
        PlaceHolder is used to hole flash file as the file is set from Admin  
     *  This file will change as per user type 1(Cat) 2(Dog) 3(cat&Dog) 
     */
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
            BindData();
        }
       if (Session["MemberName"] != null)
       {
           divUserName.Attributes.Add("style", "Display:block");
           lblWelcome.Text = "Welcome - " + Session["MemberName"].ToString();

           DataSet ds = new DataSet();
           if (!(null == Session["UserName"]))
           {
               ctlZipcode.Visible = false;
               imgbtnMakePayment.Visible = true;
           }
           else
           {
               divUserName.Attributes.Add("style", "Display:none");
               ctlZipcode.Visible = true;
               imgbtnMakePayment.Visible = false;
           }
       }
       if (Session["MemberName"] != null)
       {
           ctlZipcode.Visible = false;
          
               imgbtnMakePayment.Visible = true;
       }
       else
       {
           ctlZipcode.Visible = true;
           imgbtnMakePayment.Visible = false;
       }

    }

    protected void imgbtnMakePayment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/PaymentPrepaid.aspx");
    }
}
