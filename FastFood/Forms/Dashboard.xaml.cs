using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using FastFood.Pages;

namespace FastFood.Forms
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public int LoggedInEmp;
        public Frame currFrame;
        public Dashboard(int maNV)
        {
            InitializeComponent();

            LoggedInEmp = maNV;

            this.currFrame = new Frame();
            this.currFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            setUpTabs();
        }

        public void setUpTabs()
        {
            Frame fr1 = new Frame();
            Frame fr2 = new Frame();
            Frame fr3 = new Frame();
            Frame fr4 = new Frame();
            Frame fr5 = new Frame();
            Frame fr6 = new Frame();
            Frame fr7 = new Frame();
            Frame fr8 = new Frame();
            Frame fr9 = new Frame();
            Frame fr10 = new Frame();

            Selling selling = new Selling();
            selling.currentEmpId = LoggedInEmp;
            fr1.Content = selling;
            this.sellingTab.Content = fr1;

            Billing billing = new Billing();
            fr2.Content = billing;
            this.billingTab.Content = fr2;

            ProductManagement productManagement = new ProductManagement();
            fr3.Content = productManagement;
            this.productManagementTab.Content = fr3;

            EmployeeManagement employeeManagement = new EmployeeManagement();
            fr4.Content = employeeManagement;
            this.empTab.Content = fr4;

            RightManagement rightManagement = new RightManagement();
            fr5.Content = rightManagement;
            this.rightTab.Content = fr5;

            CustomerManagement customerManagement = new CustomerManagement();
            fr6.Content = customerManagement;
            this.cusManagementTab.Content = fr6;

            DiscountManagement discountManagement = new DiscountManagement();
            fr7.Content = discountManagement;
            this.counponManagementTab.Content = fr7;

            ImportManagement importManagement = new ImportManagement();
            fr8.Content = importManagement;
            this.importTab.Content = fr8;

            ImportDetail importDetail = new ImportDetail();
            fr9.Content = importDetail;
            this.importDetailTab.Content = fr9;

            Profile profile = new Profile(LoggedInEmp);
            fr10.Content = profile;
            this.profileTab.Content = fr10;
        }


    }
}
