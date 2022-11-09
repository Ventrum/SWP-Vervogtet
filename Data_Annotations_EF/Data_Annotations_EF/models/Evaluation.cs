using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FluentAPI_ORM.models
{
    public class Evaluation
    {
        int _eval;
        string eval_text;
        public int EvaluationId 
        { 
            get => _eval; set 
            {
                if(value <= 0)
                {
                    throw new Exception("EvaluationId must be at least 1");
                }
                else
                {
                    _eval = value;
                }
            }
        }
        public string Evaluation_Text 
        {
            get => eval_text; set
            {
                if(value.Length > 2000)
                {
                    throw new Exception("EvaluationId must be less than 2000");
                }
                else{
                    eval_text = value;
                }
            } 
        }
    }
}
