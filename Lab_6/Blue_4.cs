namespace Lab_6;

public class Blue_4
{
    public struct Team
    {
        private string _name;
        private int[] _counts;

        public readonly string Name => _name;

        public readonly int[] Scores
        {
            get
            {
                if (this._counts == null) return new int[] { };
                int[] arr = new int[this._counts.Length];

                for (int i = 0; i < this._counts.Length; i++)
                {
                    arr[i] = this._counts[i];
                }

                return arr;
            }
        }

        public int TotalScore
        {
            get
            {
                if (this._counts == null) return 0;
                int res = 0;

                for (int i = 0; i < this._counts.Length; i++)
                {
                    res += this._counts[i];
                }

                return res;
            }
        }

        public Team(string name)
        {
            this._name = name;
            this._counts = new int[] {};
        }

        public void PlayMatch(int result)
        {
            if (this._counts == null) return;

            int[] arr = new int[this._counts.Length + 1];

            for (int i = 0; i < this._counts.Length; i++)
            {
                if (i == this._counts.Length)
                {
                    arr[i] = result;
                }
                else
                {
                    arr[i] = this._counts[i];
                }
            }
        }

        public void Print()
        {
            Console.WriteLine(this.Name);
        }
    }

    public struct Group
    {
        private string _name;
        private Team[] _teams;
        
        public readonly string Name => _name;
        public readonly Team[] Teams {
            get
            {
                if (this._teams == null) return new Team[]{};
                Team[] arr = new Team[this._teams.Length];

                for (int i = 0; i < this._teams.Length; i++)
                {
                    arr[i] = this._teams[i];
                }

                return arr;
            }
        }

        public Team[] Score
        {
            get
            {
                if (_teams == null) return new Team[]{};
                Team[] result = new Team[this._teams.Length];

                for (int i = 0; i < this._teams.Length; i++)
                {
                    result[i] = _teams[i];
                }

                return result;
            }
        }

        public Group(string name)
        {
            this._name = name;
            this._teams = new Team[]{};
        }

        public void Add(Team team)
        {
            if (this._teams == null) return;
            
            Team[] arr = new Team[this._teams.Length + 1];
            
            for (int i = 0; i < this._teams.Length; i++)
            {
                if (i == this._teams.Length) arr[i] = team;
                else arr[i] = this._teams[i];
            }
        }

        public void Add(Team[] teams)
        {
            if (this._teams == null || teams.Length == 0 || this._teams.Length == 12) return;
            
            Team[] arr = new Team[this._teams.Length + teams.Length];
            
            for (int i = 0; i < this._teams.Length; i++)
            {
                arr[i] = this._teams[i];
            }

            for (int i = 0; i < teams.Length; i++)
            {
                if (this._teams.Length == 12) break;
                arr[this._teams.Length + i] = teams[i];
            }
        }

        public void Sort()
        {
            if (this._teams == null) return;
            for (int i = 0; i < this._teams.Length; i++)
            {
                for (int j = i + 1; j < this._teams.Length; j++)
                {
                    if (this._teams[j].TotalScore > this._teams[j - 1].TotalScore)
                    {
                        Team temp = this._teams[j];
                        this._teams[j] = this._teams[j - 1];
                        this._teams[j - 1] = temp;
                    }
                }
            }
        }

        public static Group Merge(Group group1, Group group2, int size)
        {
            Group group = new Group("Финалисты");
            int res = 0;
            int foo1 = 0;
            int foo2 = 0;

            while (res < size && foo1 < group1.Teams.Length && foo2 < group2.Teams.Length)
            {
                if (group1.Teams[foo1].TotalScore >= group2.Teams[foo2].TotalScore)
                {
                    group.Add(group1.Teams[foo1]);
                    foo1++;
                }
                else
                {
                    group.Add(group2.Teams[foo2]);
                    foo2++;
                }

                res++;
            }

            return group;
        }

        public void Print()
        {
            Console.WriteLine(Name);
        }
    }
}