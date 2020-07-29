using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionalUtility.FunctionalExtensions {
    public static class TaskExtensions {

        #region Task

        public static async Task BindAsync (
            this IEnumerable<Task> tasks) {
            foreach (var task in tasks) {
                await task;
            }
        }

        #endregion

    }
}