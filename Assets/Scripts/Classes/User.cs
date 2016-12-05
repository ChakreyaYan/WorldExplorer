﻿using System;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    // A delegate type for hooking up change notifications.
    public delegate void SelectedFeatureChangedEventHandler(object sender, EventArgs e);

    public class User
    {
        private string id;
        private Color selectionColor;
        private string selectedFeatureId;
        private DateTime lastUpdateReceived;

        public User()
        {
            id = Guid.NewGuid().ToString();
            LastUpdateReceived = DateTime.UtcNow;
        }

        public User(string id)
        {
            this.id = id;
            LastUpdateReceived = DateTime.UtcNow;
        }

        public string Id { get { return id; } }

        public Color SelectionColor
        {
            get { return selectionColor; }
            set { selectionColor = value; }
        }

        public string SelectedFeatureId
        {
            get { return selectedFeatureId; }
            set { selectedFeatureId = value; }
        }

        /// <summary>
        /// Last update in UTC time
        /// </summary>
        public DateTime LastUpdateReceived
        {
            get { return lastUpdateReceived; }
            set { lastUpdateReceived = value; }
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format(@"id: {0}, name: {6}, selectedFeatureId: {1}, selectionColor: r: {2}, g: {3}, b: {4}, a: {5}",
                    id, selectedFeatureId, selectionColor.r, selectionColor.g, selectionColor.b, selectionColor.a, Name);
        }

        public string ToJSON()
        {
            if (string.IsNullOrEmpty(selectedFeatureId))
            {
                // Only send the ID
                return string.Format(@"{{ ""id"": ""{0}"", ""name"": ""{1}"" }}", id, Name);
            }
            else
            {
                return string.Format(@"{{ ""id"": ""{0}"", ""name"": ""{6}"" }}, ""selectedFeatureId"": ""{1}"", ""selectionColor"": {{ ""r"": {2}, ""g"": {3}, ""b"": {4}, ""a"": {5} }} }}",
                    id, selectedFeatureId, selectionColor.r, selectionColor.g, selectionColor.b, selectionColor.a, Name);
            }
        }

        public static User FromJSON(string json)
        {
            var jsonObj = new JSONObject(json);
            var user = new User(jsonObj.GetString("id"));
            if (jsonObj.HasField("selectedFeatureId"))
            {
                user.selectedFeatureId = jsonObj.GetString("selectedFeatureId");
                if (jsonObj.HasField("selectionColor"))
                {
                    var a = jsonObj["selectionColor"].GetFloat("a", 1);
                    var r = jsonObj["selectionColor"].GetFloat("r", 1);
                    var g = jsonObj["selectionColor"].GetFloat("g", 1);
                    var b = jsonObj["selectionColor"].GetFloat("b", 1);
                    user.selectionColor = new Color(r, g, b, a);
                }
            }
            return user;
        }
    }
}