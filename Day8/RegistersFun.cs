using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace Day8
{
    public class RegistersFun
    {
        public List<string[]> Instructions { get; set; }
        public Dictionary<string, int> RegisterValues { get; set; }
        public int HighestValue { get; set; }

        public string[] ParseInstruction(string instructionPrimitive)
        {
            var instruction = new string[] { };
            if (!string.IsNullOrEmpty(instructionPrimitive))
            {
                return instructionPrimitive.Split(' ');
            }
            return instruction;
        }

        public void PopulateInstructions(string instructionPrimitives)
        {
            foreach (var instructionPrimitive in instructionPrimitives.Split('\n'))
            {
                if (instructionPrimitive.Length > 0)
                {
                    var instruction = ParseInstruction(instructionPrimitive);
                    Instructions.Add(instruction);
                    if (!RegisterValues.ContainsKey(instruction[0]))
                    {
                        RegisterValues.Add(instruction[0], 0);
                    }
                }
            }
        }

        public void ExecuteInstructions(string instructionPrimitives)
        {
            PopulateInstructions(instructionPrimitives);
            foreach (var instruction in Instructions)
            {
                var operation = instruction[5];
                var checkedRegistarValue = RegisterValues[instruction[4]];
                var conditionalValue = int.Parse(instruction[6]);
                if (operation.Equals(">")
                    ? checkedRegistarValue > conditionalValue
                    : operation.Equals("<")
                        ? checkedRegistarValue < conditionalValue
                        : operation.Equals(">=")
                            ? checkedRegistarValue >= conditionalValue
                            : operation.Equals("<=")
                                ? checkedRegistarValue <= conditionalValue
                                : operation.Equals("==")
                                    ? checkedRegistarValue == conditionalValue
                                    : checkedRegistarValue != conditionalValue)
                {
                    var currentRegisterValue = RegisterValues[instruction[0]];
                    var changeAmount = int.Parse(instruction[2]);
                    var direction = instruction[1];
                    var registerValue = direction.Equals("inc")
                        ? currentRegisterValue + changeAmount
                        : currentRegisterValue - changeAmount;

                    if (registerValue > HighestValue)
                    {
                        HighestValue = registerValue;
                    }
                    RegisterValues[instruction[0]] = registerValue;
                }
            }
        }

        public int GetLargestRegister(string instructionPrimitives)
        {
            ExecuteInstructions(instructionPrimitives);
            return RegisterValues.Values.Max();
        }
    }
}
