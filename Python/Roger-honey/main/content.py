from dataclasses import dataclass


@dataclass(frozen=True)
class NewsCard:
    number: str
    date: str
    category: str
    title: str
    description: str
    slug: str = ""


@dataclass(frozen=True)
class TeamMember:
    initials: str
    name: str
    role: str
    description: str


@dataclass(frozen=True)
class Milestone:
    year: str
    title: str
    description: str


@dataclass(frozen=True)
class FeatureCard:
    number: str
    title: str
    description: str
    url_name: str = ""


@dataclass(frozen=True)
class NavigationItem:
    label: str
    url_name: str
    active_page: str


@dataclass(frozen=True)
class ApiaryCard:
    name: str
    location: str
    description: str
    hive_count: int
    established_year: int | None = None
