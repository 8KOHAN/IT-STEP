import { useEffect, useRef, useState } from 'react';
import './ui/GroupsWidget.css'
import type IGroup from '../../entities/group/model/IGroup';
import GroupApi from '../../entities/group/api/GroupApi';
import { Link } from 'react-router-dom';

export default function GroupsWidget() {
    const [groups, setGroups] = useState<Array<IGroup>>([]);
    const cropRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        GroupApi.allGroups().then(setGroups);
    }, []);

    const rightButtonClick = () => {
        let sr = cropRef.current!.scrollWidth -
            cropRef.current!.scrollLeft -
            cropRef.current!.clientWidth;


        console.log(cropRef.current!.clientWidth,
            cropRef.current!.scrollLeft,
            cropRef.current!.scrollWidth,
            sr
        );
        cropRef.current!.scrollLeft += Math.min(sr, cropRef.current!.clientWidth / 1.25);
    };


    const leftButtonClick = () => {
        cropRef.current!.scrollLeft -= Math.min(cropRef.current!.scrollLeft, cropRef.current!.clientWidth / 1.25);
    };

    return (
        <div className='Groups-widget-wrapper'>
            <button className='btn btn-outline-light' onClick={leftButtonClick}>
                <i className='bi bi-caret-left'></i>
            </button>
            <div className='Groups-crop' ref={cropRef}>
                <div className='Groups-widget '>
                    {groups.map(g =>
                        <div className='Group-widget nav-link' key={g.id}
                            title={`Перехід до групи - ${g.name}\n${g.description}`}>
                            <Link to={`/group/${g.slug}`} key={g.id}>
                                <img src={g.imageUrl} alt={g.name} /> 
                            </Link>
                                {g.name}
                        </div>)}
                </div>
            </div>
            <button className='btn btn-outline-light' onClick={rightButtonClick}>
                <i className='bi bi-caret-right'></i>
            </button>
        </div>
    );
}