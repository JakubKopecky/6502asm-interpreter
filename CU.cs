using System;

namespace _6502asm_interpreter {
	class CU {
		public static void execute(CPU cpu, MEM memory) {
			switch (memory.getMem(cpu.PC)) {
				case 0xA9: case 0xA5: case 0xB5: case 0xAD:	case 0xBD: case 0xB9: case 0xA1: case 0xB1:
					LS_Operations.LDA.execute(cpu, memory);
					return;

				case 0x85: case 0x95: case 0x8D: case 0x9D: case 0x99: case 0x81: case 0x91:
					LS_Operations.STA.execute(cpu, memory);
					return;

				case 0xE6: case 0xEE: case 0xF6: case 0xFE:
					Inc_Dec.INC.execute(cpu, memory);
					break;

				case 0x4C: case 0x6C:
					Jmp_Calls.JMP.execute(cpu, memory);
					break;

				case 0xEA:
					System_Functions.NOP.execute(cpu, memory);
					return;

				case 0x00:
					System_Functions.BRK.execute(cpu, memory);
					return;

				default:
					Console.WriteLine("Unkown Instruction on {0:X4}, Opcode {1:X2}", cpu.PC, memory.getMem(cpu.PC));
					System_Functions.NOP.execute(cpu, memory);
					return;
			}
		}
	}
}
