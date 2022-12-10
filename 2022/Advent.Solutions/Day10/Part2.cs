using System.Diagnostics;
using System.Text;

namespace Advent.Solutions.Day10;

public class Part2
{
    private class CPU
    {
        public CPU(CRT crt)
        {
            m_crt = crt;
        }

        public int X => m_x;
        public int Cycle => m_cycle;

        private int m_x = 1;
        private int m_cycle = 1;
        private readonly CRT m_crt;
        private string[] m_program;
        private int m_instructionPointer = 0;
        public void RunProgram(IEnumerable<string> program)
        {
            m_program = program.ToArray();

            Action instructionComplete = () => { };
            int nextFreeCycle = 0;
            while (m_instructionPointer < m_program.Length)
            {
                if (m_cycle >= nextFreeCycle) {
                    instructionComplete();

                    (int cycleCount, instructionComplete) = ProcessInstruction(m_program[m_instructionPointer++]);
                    nextFreeCycle = m_cycle + cycleCount;
                }
                m_crt.Render(m_cycle, m_x);
                m_cycle++;
            }
        }

        public (int instructionCycles, Action instructionComplete) ProcessInstruction(string line) { 
            var command = line.Split(' ');
            var instruction = command[0];
            int instructionCycles = 0;
            int data = 0;
            Action action = () => { };

            if (instruction != "noop")
            {
                data = int.Parse(command[1].Trim());
            }

            switch (instruction)
            {
                case "addx":
                    action = () => { m_x += data; };
                    instructionCycles = 2;
                    break;
                case "noop":
                    instructionCycles = 1;
                    break;
                default:
                    instructionCycles = 0;
                    break;
            }

            return (instructionCycles, action);
        }
    }

    private class CRT
    {
        private readonly char[] m_display = new char[40 * 6];
        public string[] Display {
            get
            {
                var rows = new string[6];
                for (int row = 0; row < 6; row++)
                {
                    rows[row] = Row(row);
                }
                return rows;
            }
        }

        public void Render(int cycle, int xRegister)
        {
            if (Enumerable.Range(xRegister - 1, 3).Contains(cycle - 1 - ((cycle/40) * 40)))
            {
                m_display[cycle - 1] = '#';
            } else
            {
                m_display[cycle - 1] = '.';
            }
        }
        public string Row(int rowIndex)
        {
            StringBuilder row = new();

            for (int column = 0; column < 40; column++)
            {
                row.Append(m_display[column + (rowIndex * 40)]);
            }
            return row.ToString();
        }
    }

    public string[] Solution(IEnumerable<string> lines)
    {
        var crt = new CRT();
        var cpu = new CPU(crt);

        cpu.RunProgram(lines);

        return crt.Display;
    }
}
