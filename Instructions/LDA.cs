
namespace _6502asm_interpreter.LS_Operations {
	class LDA {
		public static void execute(CPU cpu, MEM memory) {
			switch (memory.getMem(cpu.PC)) {
				case 0xA9:
					LDA.LDA_IM(cpu, memory);
					return;
				case 0xA5:
				case 0xB5:
				case 0xAD:
				case 0xBD:
				case 0xB9:
				case 0xA1:
				case 0xB1:
					return;
			}
		}

		private static void LDA_IM(CPU cpu, MEM memory) {
			byte data1 = memory.getMem((ushort)(cpu.PC + 0x0001));
			cpu.A = data1;
			cpu.Z = (data1 == 0x00);
			cpu.N = (data1 & 0x80) == 0x80;
			cpu.PC += 0x02;
		}
	}
}
