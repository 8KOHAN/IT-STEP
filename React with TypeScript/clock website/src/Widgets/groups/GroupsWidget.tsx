import { useEffect, useRef, useState } from 'react';
import './ui/GroupsWidget.css'
import type IGroup from '../../Entities/group/model/IGroup';
import GroupApi from '../../Entities/group/api/GroupApi';

export default function GroupsWidget() {
    const [groups, setGroups] = useState<Array<IGroup>>([]);
    const cropRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        GroupApi.allGroups().then(setGroups);
    }, []);

    const leftButtonClick = () => {
        console.log(cropRef.current?.clientWidth,
            cropRef.current?.scrollLeft,
            cropRef.current?.scrollWidth
        );
        
    };
    return (
        <div className='Groups-widget-wrapper'>
            <button className='btn btn-outline-light' onClick={leftButtonClick}>
                <i className='bi bi-caret-left'></i>
            </button>
            <div className='Groups-crop' ref={cropRef}>
                <div className='Groups-widget '>
                    {groups.map(g => <div className='Group-widget ' key={g.id}>
                        <img src={g.imageUrl} alt={g.name} />{g.name}
                    </div>)}
                </div>
            </div>
            <button className='btn btn-outline-light'>
                <i className='bi bi-caret-right'></i>
            </button>
        </div>
    );
}