using System.Collections.Generic;
using System.Linq;

namespace voteApp
{
    public class Biz
    {
        public List<Model> VoteOptions { get; private set; }

        public Biz()
        {
            VoteOptions = new List<Model>
        {
            new Model { Option = "미국" },
            new Model { Option = "영국" },
            new Model { Option = "호주" },
            new Model { Option = "일본" },
        };
        }

        public void Vote(string option)
        {
            var voteOption = VoteOptions.FirstOrDefault(x => x.Option == option);
            if (voteOption != null)
            {
                voteOption.Votes++;
            }
        }

        public int TotalVotes => VoteOptions.Sum(x => x.Votes);

        public int GetPercentage(string option)
        {
            var voteOption = VoteOptions.FirstOrDefault(x => x.Option == option);
            if (voteOption == null || TotalVotes == 0) return 0;
            // 비율을 정수로 반올림하여 반환
            return (int)Math.Round((double)voteOption.Votes / TotalVotes * 100);
        }
    }
}
