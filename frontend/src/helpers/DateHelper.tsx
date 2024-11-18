import CalendarDay from "../components/Personal/CalendarDay/CalendarDay";

export const getDayOfWeek = (currentDate: Date) : string => {
    const dayOfWeekIndex = currentDate.getDay();
    return getDayOfWeekByID(dayOfWeekIndex);
};

export const getDayOfWeekByID = (dayIndex: number) : string => {
    switch (dayIndex) {
        case 0:
            return 'Monday';
        case 1:
            return 'Tuesday';
        case 2:
            return 'Wednesday';
        case 3:
            return 'Thursday';
        case 4:
            return 'Friday';
        case 5:
            return 'Saturday';
        case 6:
            return 'Sunday';
        default:
            return '';
    }
}

export const getArrayOfDatesFrom = (date: Date) :  JSX.Element[] => {
    const currentDay = date.getDay();
    const daysAtTheStart = currentDay === 0 ? 6 : currentDay - 1;

    const startingDate = new Date();
    startingDate.setDate(date.getDate() - daysAtTheStart)

    const days = Array.from({ length: 28 }, (_, index) => (
        <CalendarDay 
          key={index}
          day={getDateIn(startingDate, index).getDate()}
          dayOfWeek={getDayOfWeekByID(index % 7)}
          isToday={getDateIn(startingDate, index).getDate() === date.getDate()}
        />
      ));

    return days;
}

export const getDateIn = (currentDate: Date, amountOfDays: number) : Date => {
    const newDate = new Date();
    newDate.setDate(currentDate.getDate() + amountOfDays);
    return newDate;
}