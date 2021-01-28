
namespace _6502asm_interpreter.System_Functions {
	class BRK {
		public static void execute(CPU cpu, MEM memory) {
			cpu.B = true;
		}
	}
}
