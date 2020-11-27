using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PlayVsCpuController : BaseController
    {
        public PlayVsCpuController(){ }

        [HttpPost]
        public int[] CpuAction(int[] cell)
        {
            int i = checkWinner(cell);
            if(i==0){
                i = chooseMove(cell);
                if(i<9) cell[i] = 1;
            }
            i = checkWinner(cell);
            if(i >=3 ) cell[9]=i;
            return cell;
        }

        private int chooseMove(int[] cell){
            bool flag = true;
            for(int i = 0; i<9; i++){
                if(cell[i]==0){
                    flag = false;
                    break;
                }
            }
            if(flag) return 9;
            Random rand = new Random();
            while(true){
                int i = rand.Next(0, 9);
                if(cell[i] == 0) return i;
            }
        }

        private int checkWinner(int[] cell){
            int end = 0;    // 3->tie, 4->CPU, 5->player
            if(cell[0] != 0 && cell[0] == cell[1] && cell[1] == cell[2]) end = cell[0]+3;
            if(cell[0] != 0 && cell[0] == cell[3] && cell[3] == cell[6]) end = cell[0]+3;
            if(cell[0] != 0 && cell[0] == cell[4] && cell[4] == cell[8]) end = cell[0]+3;
            if(cell[1] != 0 && cell[1] == cell[4] && cell[4] == cell[7]) end = cell[1]+3;
            if(cell[2] != 0 && cell[2] == cell[5] && cell[5] == cell[8]) end = cell[2]+3;
            if(cell[2] != 0 && cell[2] == cell[4] && cell[4] == cell[6]) end = cell[2]+3;
            if(cell[3] != 0 && cell[3] == cell[4] && cell[4] == cell[5]) end = cell[3]+3;
            if(cell[6] != 0 && cell[6] == cell[7] && cell[7] == cell[8]) end = cell[6]+3;

            if(end != 0) return end;  // An exoume nikiti

            end = 3;
            for(int i = 0; i<9; i++){   // Check no more moves (tie)
                if(cell[i] == 0){
                    end = 0;
                    break;
                }
            }
            return end;
        }
    }

    public class PlayVsPlayerController : BaseController
    {
        public PlayVsPlayerController(){ }

        [HttpPost]
        public int[] CpuAction(int[] cell)
        {
            int i = checkWinner(cell);
            if(i==0){
                i = chooseMove(cell);
                if(i<9) cell[i] = 1;
            }
            i = checkWinner(cell);
            if(i >=3 ) cell[9]=i;
            return cell;
        }

        private int chooseMove(int[] cell){
            bool flag = true;
            for(int i = 0; i<9; i++){
                if(cell[i]==0){
                    flag = false;
                    break;
                }
            }
            if(flag) return 9;
            Random rand = new Random();
            while(true){
                int i = rand.Next(0, 9);
                if(cell[i] == 0) return i;
            }
        }

        private int checkWinner(int[] cell){
            int end = 0;    // 3->tie, 4->CPU, 5->player
            if(cell[0] != 0 && cell[0] == cell[1] && cell[1] == cell[2]) end = cell[0]+3;
            if(cell[0] != 0 && cell[0] == cell[3] && cell[3] == cell[6]) end = cell[0]+3;
            if(cell[0] != 0 && cell[0] == cell[4] && cell[4] == cell[8]) end = cell[0]+3;
            if(cell[1] != 0 && cell[1] == cell[4] && cell[4] == cell[7]) end = cell[1]+3;
            if(cell[2] != 0 && cell[2] == cell[5] && cell[5] == cell[8]) end = cell[2]+3;
            if(cell[2] != 0 && cell[2] == cell[4] && cell[4] == cell[6]) end = cell[2]+3;
            if(cell[3] != 0 && cell[3] == cell[4] && cell[4] == cell[5]) end = cell[3]+3;
            if(cell[6] != 0 && cell[6] == cell[7] && cell[7] == cell[8]) end = cell[6]+3;

            if(end != 0) return end;  // An exoume nikiti

            end = 3;
            for(int i = 0; i<9; i++){   // Check no more moves (tie)
                if(cell[i] == 0){
                    end = 0;
                    break;
                }
            }
            return end;
        }
    }
}