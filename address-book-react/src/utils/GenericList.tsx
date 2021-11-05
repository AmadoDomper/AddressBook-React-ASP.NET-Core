import { ReactElement } from "react";
import Loading from "./Loading";

export default function GenericList(props: genericListProps){
    if(!props.list){
        if(props.loadingUI){
            return props.loadingUI;
        }
        return <Loading />
    }else if(props.list.lenght === 0){
        if(props.empityListUI){
            return props.empityListUI;
        }
        return <>There are no elements to display</>
    }else{
        return props.children;
    }
}

interface genericListProps{
    list : any;
    loadingUI?: ReactElement;
    empityListUI?: ReactElement;
    children: ReactElement;
}