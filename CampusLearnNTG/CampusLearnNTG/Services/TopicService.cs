using CampusLearnNTG.Models;
using System.Collections.Generic;
using System.Linq;

namespace CampusLearnNTG.Services
{
    public static class TopicService
    {
        // in-memory topic list
        private static readonly List<Topic> _topics = new List<Topic>();

        public static void AddTopic(Topic topic)
        {
            _topics.Add(topic);
        }

        public static List<Topic> GetTopics()
        {
            // return a copy to avoid external mutation
            return _topics.ToList();
        }

        public static Topic GetById(string id)
        {
            return _topics.FirstOrDefault(t => t.Id == id);
        }

        public static void AddMaterials(string topicId, IEnumerable<string> filenames)
        {
            var topic = GetById(topicId);
            if (topic == null) return;

            foreach (var f in filenames)
            {
                if (!topic.Materials.Contains(f))
                    topic.Materials.Add(f);
            }
        }

        public static void RemoveMaterial(string topicId, string filename)
        {
            var topic = GetById(topicId);
            if (topic == null) return;
            topic.Materials.Remove(filename);
        }
    }
}
