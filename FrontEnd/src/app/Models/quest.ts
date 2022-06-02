import { Subquest } from "./subquest";

export interface Quest {
    id: number;
    title: string;
    category: string;
    description: string;
    points: number;
    completed: boolean;
    subQuests: Subquest[];
  }
