.class final Lcom/scanflow/datacapture/barinternal/kotlin/comparisons/ReverseOrderComparator;
.super Ljava/lang/Object;
.source "Comparisons.kt"

# interfaces
.implements Ljava/util/Comparator;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/comparisons/ReverseOrderComparator;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/comparisons/ReverseOrderComparator;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/comparisons/ReverseOrderComparator;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/comparisons/ReverseOrderComparator;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/comparisons/ReverseOrderComparator;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 323
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public compare(Ljava/lang/Comparable;Ljava/lang/Comparable;)I
    .locals 1

    const-string v0, "a"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "b"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 324
    invoke-interface {p2, p1}, Ljava/lang/Comparable;->compareTo(Ljava/lang/Object;)I

    move-result p1

    return p1
.end method

.method public bridge synthetic compare(Ljava/lang/Object;Ljava/lang/Object;)I
    .locals 0

    .line 323
    check-cast p1, Ljava/lang/Comparable;

    check-cast p2, Ljava/lang/Comparable;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/kotlin/comparisons/ReverseOrderComparator;->compare(Ljava/lang/Comparable;Ljava/lang/Comparable;)I

    move-result p1

    return p1
.end method

.method public final reversed()Ljava/util/Comparator;
    .locals 1

    .line 326
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/comparisons/NaturalOrderComparator;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/comparisons/NaturalOrderComparator;

    return-object v0
.end method
