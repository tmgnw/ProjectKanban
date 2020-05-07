using KanbanApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KanbanApi.ViewModels
{
    public class StoryVM
    {
        public Project ActiveProject { get; set; }

        public List<Project> Projects { get; set; }

        public List<TaskList> TaskLists { get; set; }

        public List<TaskStory> TaskStoryList { get; set; }

    }

    public class TaskStory
    {
        public DateTime ActionTime { get; set; }

        public string ActionType { get; set; }

        public string TaskName { get; set; }

    }

}
