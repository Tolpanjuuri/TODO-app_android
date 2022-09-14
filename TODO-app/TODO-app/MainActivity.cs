﻿using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;

namespace TODO_app
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnCreateTask;
        private Button btnAddTask;
        private DatePicker datePicker;
        private EditText TaskNameInput;
        private List<TaskItem> taskList = new List<TaskItem>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            btnCreateTask = FindViewById<Button>(Resource.Id.CreateTask);
            btnCreateTask.Click += btnCreateTask_Click;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.create_task_popup);
            TaskNameInput = FindViewById<EditText>(Resource.Id.NameInputForm);
            btnAddTask = FindViewById<Button>(Resource.Id.AddButton);
            btnAddTask.Click += btnAddTas_Click;
        }

        private void btnAddTas_Click(object sender, EventArgs e)
        {
            TaskItem task = new TaskItem();
            task.Text = TaskNameInput.Text;
            taskList.Add(task);
        }

        internal List<TaskItem> ReturnTasks()
        {
            return taskList;
        }
    }
}