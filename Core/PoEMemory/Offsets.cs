using System.Collections.Generic;
using ExileCore.Shared.Enums;
using ExileCore.Shared.Interfaces;

namespace ExileCore.PoEMemory
{
    public class Offsets
    {
        public static Offsets Regular = new Offsets { IgsOffset = 0, IgsDelta = 0, ExeName = "PathOfExile_x64" };
        public static Offsets Korean = new Offsets { IgsOffset = 0, IgsDelta = 0, ExeName = "Pathofexile_x64_KG" };

        public static Offsets Steam = new Offsets { IgsOffset = 0x28, IgsDelta = 0, ExeName = "PathOfExile_x64Steam" };

        /* FileRoot Pointer
        00007FF6C47EED01  | 48 8D 0D A8 23 7F 00               | lea rcx,qword ptr ds:[7FF6C4FE10B0]        | <--FileRootPtr
        00007FF6C47EED08  | E8 E3 5C 56 FF                     | call pathofexile_x64.7FF6C3D549F0          |
        00007FF6C47EED0D  | 48 8B 3D A4 23 7F 00               | mov rdi,qword ptr ds:[7FF6C4FE10B8]        |
        00007FF6C47EED14  | 48 8B 1F                           | mov rbx,qword ptr ds:[rdi]                 |
        00007FF6C47EED17  | 48 3B DF                           | cmp rbx,rdi                                |
        00007FF6C47EED1A  | 0F 84 26 01 00 00                  | je pathofexile_x64.7FF6C47EEE46            |
        */

        //---

        //48 8b 08 48 8d 2d ?? ?? ?? ?? 41
        //        PathOfExile_x64.exe+EEDF60 - 48 8B C4              - mov rax, rsp
        //PathOfExile_x64.exe+EEDF63 - 56                    - push rsi
        //PathOfExile_x64.exe+EEDF64 - 57                    - push rdi
        //PathOfExile_x64.exe+EEDF65 - 41 56                 - push r14
        //PathOfExile_x64.exe+EEDF67 - 48 83 EC 60           - sub rsp,60 { 96 }
        //    PathOfExile_x64.exe+EEDF6B - 48 C7 40 B8 FEFFFFFF  - mov qword ptr[rax - 48],FFFFFFFFFFFFFFFE { -2 }
        //PathOfExile_x64.exe + EEDF73 - 48 89 58 10 - mov[rax + 10],rbx
        //PathOfExile_x64.exe+EEDF77 - 48 89 68 18           - mov[rax + 18], rbp
        //PathOfExile_x64.exe+EEDF7B - 0F29 70 D8            - movaps[rax - 28], xmm6
        //PathOfExile_x64.exe+EEDF7F - 0F29 78 C8            - movaps[rax - 38], xmm7
        //PathOfExile_x64.exe+EEDF83 - 41 BE 40000000        - mov r14d,00000040 { 64 }
        //PathOfExile_x64.exe + EEDF89 - 65 48 8B 04 25 58000000 - mov rax,gs:[00000058] { 88 }
        //PathOfExile_x64.exe + EEDF92 - 48 8B 08 - mov rcx,[rax]
        //PathOfExile_x64.exe + EEDF95 - 48 8D 2D A4117602 - lea rbp,[PathOfExile_x64.exe+364F140] { (1.00) }
        //PathOfExile_x64.exe + EEDF9C - 41 8B 04 0E - mov eax,[r14+rcx]
        //PathOfExile_x64.exe + EEDFA0 - 39 05 92117602 - cmp[PathOfExile_x64.exe + 364F138],eax
        //{ (-2147483634) }
        //PathOfExile_x64.exe + EEDFA6 - 0F8E 84010000 - jng PathOfExile_x64.exe + EEE130
        //PathOfExile_x64.exe + EEDFAC - 48 8D 0D 85117602 - lea rcx,[PathOfExile_x64.exe+364F138] { (-2147483634) }
        //PathOfExile_x64.exe + EEDFB3 - E8 88877C00 - call PathOfExile_x64.exe + 16B6740
        //PathOfExile_x64.exe+EEDFB8 - 83 3D 79117602 FF     - cmp dword ptr[PathOfExile_x64.exe + 364F138],-01 { (-2147483634),255 }
        //PathOfExile_x64.exe + EEDFBF - 0F85 6B010000 - jne PathOfExile_x64.exe + EEE130
        //PathOfExile_x64.exe + EEDFC5 - 48 8D 05 74F0FFFF - lea rax,[PathOfExile_x64.exe+EED040] { (35817) }
        //PathOfExile_x64.exe + EEDFCC - 48 89 44 24 20 - mov[rsp + 20],rax
        //PathOfExile_x64.exe+EEDFD1 - 4C 8D 0D 08050000     - lea r9, [PathOfExile_x64.exe+EEE4E0] { (608995656) }
        //PathOfExile_x64.exe + EEDFD8 - BA 40000000 - mov edx,00000040 { 64 }
        //PathOfExile_x64.exe + EEDFDD - 44 8D 42 40 - lea r8d,[rdx+40]
        //PathOfExile_x64.exe + EEDFE1 - 48 8B CD              - mov rcx, rbp
        //PathOfExile_x64.exe+EEDFE4 - E8 3B8B7C00           - call PathOfExile_x64.exe+16B6B24
        //PathOfExile_x64.exe+EEDFE9 - 90                    - nop 
        //PathOfExile_x64.exe+EEDFEA - 48 8D 0D 4F317602     - lea rcx,[PathOfExile_x64.exe + 3651140] { (1.00) }
        //PathOfExile_x64.exe + EEDFF1 - 48 8D 05 38F0FFFF - lea rax,[PathOfExile_x64.exe+EED030] { (7145) }
        //PathOfExile_x64.exe + EEDFF8 - 48 89 44 24 20 - mov[rsp + 20],rax
        //PathOfExile_x64.exe+EEDFFD - 4C 8D 0D 4C020000     - lea r9, [PathOfExile_x64.exe+EEE250] { (608995656) }
        //PathOfExile_x64.exe + EEE004 - BA 40000000 - mov edx,00000040 { 64 }


        private static readonly Pattern FileRootPattern =
                    new Pattern(new byte[]
                        {
                    0x48, 0x8b, 0x08,
                    0x48, 0x8d, 0x2d,
                    0x00, 0x00, 0x00, 0x00,
                    0x41

                        }, "xxxxxx????x", "File Root",
                        14630000);

        /* Area Change
        00007FF63317CE40 | 48 83 EC 58                    | sub rsp,58                                      |
        00007FF63317CE44 | 4C 8B C1                       | mov r8,rcx                                      |
        00007FF63317CE47 | 41 B9 01 00 00 00              | mov r9d,1                                       |
        00007FF63317CE4D | 48 8B 49 10                    | mov rcx,qword ptr ds:[rcx+10]                   |
        00007FF63317CE51 | 48 89 4C 24 30                 | mov qword ptr ss:[rsp+30],rcx                   |
        00007FF63317CE56 | 48 85 C9                       | test rcx,rcx                                    |
        00007FF63317CE59 | 74 11                          | je pathofexile_x64 - alpha 2.5.7FF63317CE6C     |
        00007FF63317CE5B | 41 8B C1                       | mov eax,r9d                                     |
        00007FF63317CE5E | F0 0F C1 41 54                 | lock xadd dword ptr ds:[rcx+54],eax             |
        00007FF63317CE63 | 8B 05 7B 09 F0 00              | mov eax,dword ptr ds:[<AreaChangeCount>]        |
        00007FF63317CE69 | 89 41 50                       | mov dword ptr ds:[rcx+50],eax                   |
        00007FF63317CE6C | 49 8B 08                       | mov rcx,qword ptr ds:[r8]                       |
        00007FF63317CE6F | 49 8B 40 18                    | mov rax,qword ptr ds:[r8+18]                    |
        */

        private static readonly Pattern AreaChangePattern =
            new Pattern(
                new byte[]
                {
                    0xE8,
                    0x00, 0x00, 0x00, 0x00,
                    0xE8,
                    0x00, 0x00, 0x00, 0x00,
                    0xFF, 0x05
                }, "x????x????xx", "Area change", 9430000);

        /*
        PathOfExile_x64.exe+118FD9 - 4C 8B 35 48255B01     - mov r14,[PathOfExile_x64.exe+16CB528] { [C6151734A0] }<<here
        PathOfExile_x64.exe+118FE0 - 4D 85 F6              - test r14,r14
        PathOfExile_x64.exe+118FE3 - 0F94 C0               - sete al
        PathOfExile_x64.exe+118FE6 - 84 C0                 - test al,al
        */

        //-----
        //gamestatepattern
        //48 83 ec 50 48 c7 44 24 ?? ?? ?? ?? ?? 48 89 9c 24 ?? ?? ?? ?? 488b f9 33 ed 48 39
        //
        //PathOfExile_x64.exe+16B6F30 - 48 83 EC 28           - sub rsp,28 { 40 }
        //PathOfExile_x64.exe+16B6F34 - E8 93090000           - call PathOfExile_x64.exe+16B78CC
        //PathOfExile_x64.exe+16B6F39 - 48 83 C4 28           - add rsp,28 { 40 }
        //PathOfExile_x64.exe+16B6F3D - E9 7AFEFFFF           - jmp PathOfExile_x64.exe+16B6DBC
        //PathOfExile_x64.exe+16B6F42 - CC                    - int 3 
        //PathOfExile_x64.exe+16B6F43 - CC                    - int 3 
        //PathOfExile_x64.exe+16B6F44 - 48 83 EC 28           - sub rsp,28 { 40 }
        //PathOfExile_x64.exe+16B6F48 - 4D 8B 41 38           - mov r8,[r9 + 38]
        //PathOfExile_x64.exe+16B6F4C - 48 8B CA              - mov rcx, rdx
        //PathOfExile_x64.exe+16B6F4F - 49 8B D1              - mov rdx, r9
        //PathOfExile_x64.exe+16B6F52 - E8 0D000000           - call PathOfExile_x64.exe+16B6F64
        //PathOfExile_x64.exe+16B6F57 - B8 01000000           - mov eax,00000001 { 1 }
        //PathOfExile_x64.exe+16B6F5C - 48 83 C4 28           - add rsp,28 { 40 }
        //PathOfExile_x64.exe + 16B6F60 - C3 - ret
        //PathOfExile_x64.exe + 16B6F61 - CC - int 3
        //PathOfExile_x64.exe + 16B6F62 - CC - int 3
        //PathOfExile_x64.exe + 16B6F63 - CC - int 3
        //PathOfExile_x64.exe + 16B6F64 - 40 53 - push rbx
        //PathOfExile_x64.exe+16B6F66 - 45 8B 18              - mov r11d, [r8]
        //PathOfExile_x64.exe+16B6F69 - 48 8B DA              - mov rbx, rdx
        //PathOfExile_x64.exe+16B6F6C - 41 83 E3 F8           - and r11d,-08 { 248 }
        //PathOfExile_x64.exe + 16B6F70 - 4C 8B C9              - mov r9, rcx
        //PathOfExile_x64.exe+16B6F73 - 41 F6 00 04           - test byte ptr [r8],04 { 4 }
        //PathOfExile_x64.exe + 16B6F77 - 4C 8B D1              - mov r10, rcx
        //PathOfExile_x64.exe+16B6F7A - 74 13                 - je PathOfExile_x64.exe+16B6F8F
        //PathOfExile_x64.exe+16B6F7C - 41 8B 40 08           - mov eax,[r8 + 08]
        //PathOfExile_x64.exe+16B6F80 - 4D 63 50 04           - movsxd  r10, dword ptr [r8+04]
        //PathOfExile_x64.exe + 16B6F84 - F7 D8 - neg eax
        //PathOfExile_x64.exe+16B6F86 - 4C 03 D1              - add r10, rcx
        //PathOfExile_x64.exe+16B6F89 - 48 63 C8              - movsxd rcx, eax
        //PathOfExile_x64.exe+16B6F8C - 4C 23 D1              - and r10, rcx
        //PathOfExile_x64.exe+16B6F8F - 49 63 C3              - movsxd rax, r11d
        //PathOfExile_x64.exe+16B6F92 - 4A 8B 14 10           - mov rdx, [rax+r10]
        //PathOfExile_x64.exe+16B6F96 - 48 8B 43 10           - mov rax, [rbx+10]
        //PathOfExile_x64.exe+16B6F9A - 8B 48 08              - mov ecx, [rax+08]
        //PathOfExile_x64.exe+16B6F9D - 48 8B 43 08           - mov rax, [rbx+08]
        //PathOfExile_x64.exe+16B6FA1 - F6 44 01 03 0F        - test byte ptr [rcx+rax+03],0F { 15 }
        //PathOfExile_x64.exe + 16B6FA6 - 74 0B - je PathOfExile_x64.exe + 16B6FB3
        //PathOfExile_x64.exe+16B6FA8 - 0FB6 44 01 03         - movzx eax, byte ptr [rcx+rax+03]
        //PathOfExile_x64.exe+16B6FAD - 83 E0 F0              - and eax,-10 { 240 }
        //PathOfExile_x64.exe + 16B6FB0 - 4C 03 C8 - add r9,rax
        //PathOfExile_x64.exe+16B6FB3 - 4C 33 CA              - xor r9, rdx
        //PathOfExile_x64.exe+16B6FB6 - 49 8B C9              - mov rcx, r9
        //PathOfExile_x64.exe+16B6FB9 - 5B                    - pop rbx
        //PathOfExile_x64.exe+16B6FBA - E9 11000000           - jmp PathOfExile_x64.exe+16B6FD0
        //PathOfExile_x64.exe+16B6FBF - CC                    - int 3 
        //PathOfExile_x64.exe+16B6FC0 - CC                    - int 3 
        //PathOfExile_x64.exe+16B6FC1 - CC                    - int 3 
        //PathOfExile_x64.exe+16B6FC2 - CC                    - int 3 
        //PathOfExile_x64.exe+16B6FC3 - CC                    - int 3 
        //PathOfExile_x64.exe+16B6FC4 - CC                    - int 3 
        //PathOfExile_x64.exe+16B6FC5 - CC                    - int 3 
        //PathOfExile_x64.exe+16B6FC6 - 66 66 0F1F 84 00 00000000  - nop word ptr[rax + rax + 00000000]
        //PathOfExile_x64.exe+16B6FD0 - 48 3B 0D F181C801     - cmp rcx, [PathOfExile_x64.exe+333F1C8] { (-392410573) }
        //PathOfExile_x64.exe + 16B6FD7 - F2 75 12 - repne jne PathOfExile_x64.exe+16B6FEC
        //PathOfExile_x64.exe+16B6FDA - 48 C1 C1 10           - rol rcx,10 { 16 }
        //PathOfExile_x64.exe + 16B6FDE - 66 F7 C1 FFFF         - test cx, FFFF { 65535 }


        private static readonly Pattern GameStatePattern = new Pattern(
            new byte[]
            {
                0x48, 0x83, 0xec, 0x50, 0x48, 0xc7, 0x44, 0x24, 0x00, 0x00, 0x00, 0x00, 0x00, 0x48, 0x89, 0x9c, 0x24, 0x00, 0x00, 0x00, 0x00, 0x48,
                0x8b, 0xf9, 0x33, 0xed, 0x48, 0x39
            }, "xxxxxxxx?????xxxx????xxxxxxx", "Game State", 1240000);

        public long AreaChangeCount { get; private set; }
        public long Base { get; private set; }
        public string ExeName { get; private set; }
        public long FileRoot { get; private set; }
        public int IgsDelta { get; private set; }
        public int IgsOffset { get; private set; }
        public int IgsOffsetDelta => IgsOffset + IgsDelta;
        public long isLoadingScreenOffset { get; private set; }
        public long GameStateOffset { get; private set; }

        public Dictionary<OffsetsName, long> DoPatternScans(IMemory m)
        {
            var array = m.FindPatterns(FileRootPattern, AreaChangePattern, GameStatePattern);

            var result = new Dictionary<OffsetsName, long>();

            //  System.Console.WriteLine("Base Pattern: " + (m.AddressOfProcess + array[0]).ToString("x8"));

            var index = 0;
            var baseAddress = m.Process.MainModule.BaseAddress.ToInt64();

            FileRoot = m.Read<int>(baseAddress + array[index] + 6) + array[index] + 10;
            index++;
            //FileRoot = 0x362CCC0; 3.11.0c

            AreaChangeCount = m.Read<int>(baseAddress + array[index] + 0xC) + array[index] + 0x10;
            index++;
            //AreaChangeCount = 0x336AA88; 3.11.0f


            GameStateOffset = m.Read<int>(baseAddress + array[index] + 29) + array[index] + 33;

            result.Add(OffsetsName.FileRoot, FileRoot);
            result.Add(OffsetsName.AreaChangeCount, AreaChangeCount);
            result.Add(OffsetsName.GameStateOffset, GameStateOffset);
            return result;
        }
    }
}
