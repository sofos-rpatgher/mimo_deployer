using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimo_Interpreter
{
    internal class MimoProgram
    {
        public string batch_id { get; set; }
        public string batch_iid { get; set; }
        public string program_id { get; set; }
        public string program_iid { get; set; }
        public string program_name { get; set; }
        public string program_ver { get; set; }
        public List<Block> blocks;
    }

    internal class Block
    {
        public string block_id { get; set; }
        public string block_iid { get; set; }
        public int block_seq { get; set; }
        public string tOrder_id { get; set; }
        public List<Instruction> instructions;
    }

    internal class Instruction
    {
        public string instruction_id { get; set; }
        public string instruction_iid { get; set; }
        public int instruction_seq { get; set; }
        public List<Instance> instances;
    }

    internal class Instance
    {
        public string instance_iid { get; set; }
        public int instance_seq { get; set; }
        public List<Intent> intents;
    }
    internal class Intent
    {
        public string intent_id { get; set; }
        public string intent_iid { get; set; }
        public int intent_seq { get; set; }
        public List<Activity> code;
        public List<Activity> rollback;
    }
    internal class Activity
    {
        public string action_id { get; set; }
        public string type_code { get; set; }
        public string value { get; set; }
        public string command_id { get; set; }
        public string table_id { get; set; }
        public string row_value { get; set; }
        public string column_id { get; set; }
    }
}
