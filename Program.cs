using System;

// http://www.obelisk.me.uk/6502/

namespace _6502asm_interpreter {

	class Program {

		private static int cycles = 0;

		private static void printFirstChunk(MEM memory) {
			Console.WriteLine("First 256 bytes of memory\n");
			int limit = 0x00FF + 1;
			Console.WriteLine("      00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F");
			Console.WriteLine("      -----------------------------------------------");
			for (int i = 0; i < limit / 16; i++) { //pocet riadkov
				Console.Write("{0:X4}: ", i * 16);
				for (int j = 0; j < 16; j++) { //riadok
					Console.Write("{0:X2} ", memory.getMem((ushort)((i * 16) + j)));
				}
				Console.Write("\n");
			}
		}

		static void Main(string[] args) {
			MEM memory = new MEM();
			CPU cpu = new CPU(memory);

			
			memory.setMem(0xFFFC, 0x00); //reset vector
			memory.setMem(0xFFFD, 0x00);
			
			memory.setMem(0x0000, 0xA9);// LDA 0x05
			memory.setMem(0x0001, 0x05);
			memory.setMem(0x0002, 0xEA); //NOP
			memory.setMem(0x0003, 0x85);// STA 0x00FF
			memory.setMem(0x0004, 0x00);
			memory.setMem(0x0005, 0xFF);
			memory.setMem(0x0006, 0xE6);// INC 0x00FF
			memory.setMem(0x0007, 0x00);
			memory.setMem(0x0008, 0xFF);

			memory.setMem(0x0009, 0x00); // BRK
			
			cpu.reset();
			while (!cpu.B) {
				cpu.tick();
				cycles++;
			}
			printFirstChunk(memory);
			Console.WriteLine("\nPC is at " + cpu.PC);
			Console.WriteLine("Was runnig for " + cycles + " cycles");
			Console.WriteLine("Result is " + memory.getMem(0x00FF));
		}
	}
}
