.class public final enum Lcom/scanflow/datacapture/barinternal/j/d;
.super Ljava/lang/Enum;
.source "SourceFile"


# static fields
.field public static final enum b:Lcom/scanflow/datacapture/barinternal/j/d;

.field public static final enum c:Lcom/scanflow/datacapture/barinternal/j/d;

.field public static final enum d:Lcom/scanflow/datacapture/barinternal/j/d;

.field public static final synthetic e:[Lcom/scanflow/datacapture/barinternal/j/d;


# instance fields
.field public final a:Z


# direct methods
.method static constructor <clinit>()V
    .locals 6

    new-instance v0, Lcom/scanflow/datacapture/barinternal/j/d;

    const-string v1, "CONNECTED"

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-direct {v0, v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/j/d;-><init>(Ljava/lang/String;IZ)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/j/d;->b:Lcom/scanflow/datacapture/barinternal/j/d;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/j/d;

    const-string v4, "DISCONNECTING"

    invoke-direct {v1, v4, v3, v2}, Lcom/scanflow/datacapture/barinternal/j/d;-><init>(Ljava/lang/String;IZ)V

    sput-object v1, Lcom/scanflow/datacapture/barinternal/j/d;->c:Lcom/scanflow/datacapture/barinternal/j/d;

    new-instance v3, Lcom/scanflow/datacapture/barinternal/j/d;

    const-string v4, "DISCONNECTED"

    const/4 v5, 0x2

    invoke-direct {v3, v4, v5, v2}, Lcom/scanflow/datacapture/barinternal/j/d;-><init>(Ljava/lang/String;IZ)V

    sput-object v3, Lcom/scanflow/datacapture/barinternal/j/d;->d:Lcom/scanflow/datacapture/barinternal/j/d;

    .line 1
    filled-new-array {v0, v1, v3}, [Lcom/scanflow/datacapture/barinternal/j/d;

    move-result-object v0

    .line 2
    sput-object v0, Lcom/scanflow/datacapture/barinternal/j/d;->e:[Lcom/scanflow/datacapture/barinternal/j/d;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/enums/EnumEntriesKt;->enumEntries([Ljava/lang/Enum;)Lkotlin/enums/EnumEntries;

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;IZ)V
    .locals 0

    .line 1
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    iput-boolean p3, p0, Lcom/scanflow/datacapture/barinternal/j/d;->a:Z

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/j/d;
    .locals 1

    .line 1
    const-class v0, Lcom/scanflow/datacapture/barinternal/j/d;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/j/d;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/j/d;
    .locals 1

    .line 1
    sget-object v0, Lcom/scanflow/datacapture/barinternal/j/d;->e:[Lcom/scanflow/datacapture/barinternal/j/d;

    invoke-virtual {v0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/j/d;

    return-object v0
.end method
