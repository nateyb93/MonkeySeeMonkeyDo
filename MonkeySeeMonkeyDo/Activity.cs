using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeySeeMonkeyDo
{
    public class Activity
    {
        public string ActivityName;

        public Activity(string name)
        {
            this.ActivityName = name;
        }
        public static List<Activity> GetList()
        {
            List<Activity> activities = new List<Activity>();

            activities.Add(new Activity("CompSci"));
            activities.Add(new Activity("MonkeyDo"));
            activities.Add(new Activity("Math"));

            return activities;
        }
    }
}
