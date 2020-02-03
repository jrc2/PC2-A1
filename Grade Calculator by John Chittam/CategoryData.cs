using System;
using System.Data;
using System.Xml.Serialization;

namespace Grade_Calculator_by_John_Chittam
{
    [Serializable]
    public class CategoryData
    {
        /// <summary>
        /// Gets or sets the grades.
        /// </summary>
        /// <value>
        /// The grades.
        /// </value>
        public DataTable Grades { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public int Weight { get; set; }

        public CategoryData()
        {
            this.Grades = new DataTable();
            this.Weight = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryData"/> class.
        /// </summary>
        /// <param name="grades">The grades.</param>
        /// <param name="weight">The weight.</param>
        public CategoryData(DataTable grades, int weight)
        {
            this.Weight = weight;
            this.Grades = grades;
        }
    }
}
