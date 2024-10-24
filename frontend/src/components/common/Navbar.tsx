type Props = {};
function Navbar(props: Props) {
  return (
    <>
      <a
        href="/dashboard"
        className="text-foreground transition-colors hover:text-foreground"
      >
        Dashboard
      </a>
      <a
        href="/employees"
        className="text-muted-foreground transition-colors hover:text-foreground"
      >
        Employees
      </a>
      <a
        href="#"
        className="text-muted-foreground transition-colors hover:text-foreground"
      >
        Approval
      </a>
      <a
        href="#"
        className="text-muted-foreground transition-colors hover:text-foreground"
      >
        Reports
      </a>
      <a
        href="#"
        className="text-muted-foreground transition-colors hover:text-foreground"
      >
        Invoices
      </a>
      <a
        href="#"
        className="text-muted-foreground transition-colors hover:text-foreground"
      >
        Requests
      </a>
    </>
  );
}

export default Navbar;
