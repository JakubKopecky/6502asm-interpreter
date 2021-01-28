
namespace _6502asm_interpreter.LS_Operations {
	class STA {
		public static void execute(CPU cpu, MEM memory) {
			switch (memory.getMem(cpu.PC)) {
				case 0x85:
					STA.STA_ZP(cpu, memory);
					return;
				case 0x95:
				case 0x8D:
				case 0x9D:
				case 0x99:
				case 0x81:
				case 0x91:
					return;
			}
		}

		private static void STA_ZP(CPU cpu, MEM memory) {
			byte data1 = memory.getMem((ushort)(cpu.PC + 0x0001));
			byte data2 = memory.getMem((ushort)(cpu.PC + 0x0002));
			memory.setMem(data1, data2, cpu.A);
			cpu.PC += 3;
		}
	}
}
