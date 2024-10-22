namespace Math_Graph_Toolkit_SixLabors
{
    public class OptionMenu<T>
        where T : notnull
    {
        public string title;
        public Dictionary<T, Action> options;

        public OptionMenu(string title, Dictionary<T, Action> options)
        {
            this.title = title;
            this.options = options;
        }

        public void Show()
        {
            Console.WriteLine(title);
            
            int? selectedIndex = null;
            while (selectedIndex is null)
            {
                var i = 0;
                foreach (var option in options)
                    Console.WriteLine($"{i++ + 1, -10}{option.Key}");

                Console.Write("> ");

                int index;
                if (!int.TryParse(Console.ReadLine()!, out index))
                {
                    Console.WriteLine("Not a valid Int32 number");
                    continue;
                }

                --index;
                if (index < 0 || index >= options.Count)
                {
                    Console.WriteLine("Invalid selection");
                    continue;
                }

                selectedIndex = index;
                break;
            }

            options.ElementAt(selectedIndex.Value).Value();
        }
    }
}