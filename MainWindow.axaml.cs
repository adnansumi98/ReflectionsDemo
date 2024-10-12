using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;


namespace ReflectionsDemo
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            lstMethods.ItemsSource = new string[] { "initial render" }.OrderBy(x => x);
            lstProperties.ItemsSource = new string[] { "initial render" }.OrderBy(x => x);
            lstConstructors.ItemsSource = new string[] { "initial render" }.OrderBy(x => x);
        }

        public static string ToTitleCase(string str)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }


        public void btnDiscoverTypeInformation_Click(object? sender, RoutedEventArgs args)
        {
            string? typeName = txtTypeName.Text;

            if (!string.IsNullOrEmpty(typeName))
            {
                // Clear previous items
                lstMethods.ItemsSource = new string[] { "cleared List box" }.OrderBy(x => x);
                lstProperties.ItemsSource = new string[] { "cleared List box" }.OrderBy(x => x);
                lstConstructors.ItemsSource = new string[] { "cleared List box" }.OrderBy(x => x);
                // emaple used is System.String
                // Convert to title case for proper comparision
                Type? T = Type.GetType(ToTitleCase(typeName.ToString().ToLower()));

                if (T != null)
                {
                    MethodInfo[] methods = T.GetMethods();
                    List<string> methodList = new List<string>();

                    foreach (MethodInfo method in methods)
                    {
                        methodList.Add(method.ReturnType.Name + " " + method.Name);
                    }

                    lstMethods.ItemsSource = methodList.OrderBy(x => x);

                    PropertyInfo[] properties = T.GetProperties();
                    List<string> PropertyList = new List<string>();
                    foreach (PropertyInfo property in properties)
                    {
                        PropertyList.Add(property.PropertyType.Name + ": " + property.Name);
                    }

                    lstProperties.ItemsSource = PropertyList.OrderBy(x => x);

                    ConstructorInfo[] constructors = T.GetConstructors();
                    List<string> ConstructorsList = new List<string>();
                    foreach (ConstructorInfo constructor in constructors)
                    {
                        ConstructorsList.Add(constructor.ToString());
                    }

                    lstConstructors.ItemsSource = ConstructorsList.OrderBy(x => x);
                }


            }
        }
    }
}
