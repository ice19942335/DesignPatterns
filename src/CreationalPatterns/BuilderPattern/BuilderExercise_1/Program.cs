using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderExercise_1
{
    public class Class
    {
        public string Name { get; set; }

        public IList<Field> Fields { get; set; } = new List<Field>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Name}").AppendLine("{");
            foreach (var field in Fields)
                sb.AppendLine($"  {field};");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class Field
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return $"public {Type} {Name}";
        }
    }

    public class CodeBuilder
    {
        private Class _class = new Class();

        public CodeBuilder(string className)
        {
            _class.Name = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            _class.Fields.Add(new Field{ Name = name, Type = type});
            return this;
        }

        public override string ToString()
        {
            return _class.ToString();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            CodeBuilder cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int");

            Console.WriteLine(cb);
        }
    }
}