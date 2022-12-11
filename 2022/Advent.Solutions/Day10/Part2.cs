using System.Text;

namespace Advent.Solutions.Day10;

public class Part2
{
    private class CPU
    {
        public CPU(CRT crt, string[] program)
        {
            m_crt = crt;
            m_program = program;
        }

        public int X => m_x;
        public int Cycle => m_cycle;

        private int m_x = 1;
        private int m_cycle = 1;
        private readonly CRT m_crt;
        private readonly string[] m_program;
        private int m_instructionPointer = 0;

        public void RunProgram()
        {
            Func<int, bool> instructionComplete = (c) => { return true; };
            while (m_instructionPointer < m_program.Length)
            {
                if (instructionComplete(m_cycle))
                {
                    instructionComplete = ProcessInstruction(m_cycle, m_program[m_instructionPointer++]);
                }
                m_crt.Render(m_cycle, m_x);
                m_cycle++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clockCycle"></param>
        /// <param name="line"></param>
        /// <returns>A function that executes an operation when the appropriate clock cycle has been reached.</returns>
        public Func<int, bool> ProcessInstruction(int clockCycle, string line)
        {
            var command = line.Split(' ');
            var instruction = command[0];
            int data = 0;

            Func<int, bool> action = (c) => { return true; };

            switch (instruction)
            {
                case "addx":
                    action = (int cycle) =>
                    {
                        data = int.Parse(command[1].Trim());
                        if (cycle == clockCycle + 2)
                        {
                            m_x += data;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    };
                    break;
                case "noop":
                default:
                    break;
            }

            return action;
        }
    }

    private class CRT
    {
        private readonly int m_columns;
        private readonly int m_rows;

        private readonly char[] m_display;

        public CRT(int columns, int rows)
        {
            m_rows = rows;
            m_columns = columns;
            m_display = new char[columns * rows];
        }

        public string[] Display
        {
            get
            {
                var rows = new string[m_rows];
                for (int row = 0; row < m_rows; row++)
                {
                    rows[row] = Row(row);
                }
                return rows;
            }
        }

        public void Render(int cycle, int xRegister)
        {
            if (Enumerable.Range(xRegister - 1, 3).Contains((cycle % m_columns) - 1))
            {
                m_display[cycle - 1] = '#';
            }
            else
            {
                m_display[cycle - 1] = '.';
            }
        }

        public string Row(int rowIndex)
        {
            StringBuilder row = new();

            for (int column = 0; column < m_columns; column++)
            {
                row.Append(m_display[column + (rowIndex * m_columns)]);
            }
            return row.ToString();
        }
    }

    public string[] Solution(IEnumerable<string> lines)
    {
        var crt = new CRT(40, 6);
        var cpu = new CPU(crt, lines.ToArray());

        cpu.RunProgram();

        return crt.Display;
    }
}
