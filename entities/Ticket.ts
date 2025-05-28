import { Entity, PrimaryGeneratedColumn, ManyToOne } from "typeorm";
import { User } from "./User";
import { Event } from "./Event";

@Entity()
export class Ticket {
    @PrimaryGeneratedColumn()
    id: number;

    @ManyToOne(() => User, (user) => user.tickets)
    user: User;

    @ManyToOne(() => Event, (event) => event.tickets)
    event: Event;
}
