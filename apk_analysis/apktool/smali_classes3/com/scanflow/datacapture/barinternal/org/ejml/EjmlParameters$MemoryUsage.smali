.class public final enum Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;
.super Ljava/lang/Enum;
.source "EjmlParameters.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "MemoryUsage"
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

.field public static final enum FASTER:Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

.field public static final enum LOW_MEMORY:Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;
    .locals 2

    .line 77
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;->LOW_MEMORY:Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;->FASTER:Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    filled-new-array {v0, v1}, [Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 81
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    const-string v1, "LOW_MEMORY"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;->LOW_MEMORY:Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    .line 85
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    const-string v1, "FASTER"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;->FASTER:Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    .line 77
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;->$values()[Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;->$VALUES:[Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 77
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;
    .locals 1

    .line 77
    const-class v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;
    .locals 1

    .line 77
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;->$VALUES:[Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    return-object v0
.end method
