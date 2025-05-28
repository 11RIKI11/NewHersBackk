import { Entity, PrimaryGeneratedColumn, ManyToOne } from "typeorm";
import { User } from "./User";
import { Event } from "./Event";

@Entity()
export class Calendar {
    @PrimaryGeneratedColumn()
    id: number;

    @ManyToOne(() => User, (user) => user.id)
    user: User;

    @ManyToOne(() => Event, (event) => event.id)
    event: Event;
}
